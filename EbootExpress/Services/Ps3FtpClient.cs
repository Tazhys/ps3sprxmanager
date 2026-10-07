using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EbootExpress
{
    internal sealed class FtpConnectionSettings
    {
        internal FtpConnectionSettings(string host, int port, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(host) || Uri.CheckHostName(host) == UriHostNameType.Unknown
                || host.IndexOfAny(new[] { '/', '\\', '@', '?' }) >= 0)
            {
                throw new ArgumentException("Enter a valid PS3 FTP host name or IP address.", "host");
            }
            if (port < 1 || port > 65535)
            {
                throw new ArgumentException("Enter a valid FTP port between 1 and 65535.", "port");
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Enter the FTP username configured on the PS3.", "userName");
            }

            Host = host;
            Port = port;
            UserName = userName;
            Password = password ?? string.Empty;
        }

        internal string Host { get; private set; }
        internal int Port { get; private set; }
        internal string UserName { get; private set; }
        internal string Password { get; private set; }
    }

    internal sealed class FtpTransferProgress
    {
        internal FtpTransferProgress(long bytesSent, long totalBytes)
        {
            BytesSent = bytesSent;
            TotalBytes = totalBytes;
        }

        internal long BytesSent { get; private set; }
        internal long TotalBytes { get; private set; }
    }

    internal sealed class Ps3FtpClient
    {
        private const int RequestTimeoutMilliseconds = 15000;
        private const int TransferBufferSize = 81920;
        private readonly FtpConnectionSettings settings;

        internal Ps3FtpClient(FtpConnectionSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException("settings");
        }

        internal async Task TestDirectoryAsync(string remoteDirectory, CancellationToken cancellationToken)
        {
            string normalizedDirectory = NormalizeRemoteDirectory(remoteDirectory);
            FtpWebRequest request = CreateRequest(normalizedDirectory, WebRequestMethods.Ftp.ListDirectory);
            using (cancellationToken.Register(request.Abort))
            {
                try
                {
                    using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                    {
                        if (!IsSuccessfulFtpResponse(response.StatusCode))
                        {
                            throw new WebException(response.StatusDescription);
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw new OperationCanceledException("The FTP request was canceled.", ex, cancellationToken);
                    }

                    throw;
                }
            }
        }

        internal async Task<IList<string>> ListDirectoryAsync(
            string remoteDirectory,
            CancellationToken cancellationToken)
        {
            string normalizedDirectory = NormalizeRemoteDirectory(remoteDirectory);
            FtpWebRequest request = CreateRequest(normalizedDirectory, WebRequestMethods.Ftp.ListDirectory);
            using (cancellationToken.Register(request.Abort))
            {
                try
                {
                    using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                    {
                        if (!IsSuccessfulFtpResponse(response.StatusCode))
                        {
                            throw new WebException(response.StatusDescription);
                        }

                        using (Stream responseStream = response.GetResponseStream())
                        {
                            if (responseStream == null)
                            {
                                throw new WebException("The FTP server returned no directory listing.");
                            }

                            using (StreamReader reader = new StreamReader(responseStream, Encoding.ASCII))
                            {
                                string listing = await reader.ReadToEndAsync();
                                List<string> entries = new List<string>();
                                foreach (string line in listing.Split(
                                    new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    string entry = line.Trim();
                                    if (entry.Length > 0 && entry != "." && entry != "..")
                                    {
                                        entries.Add(entry);
                                    }
                                }

                                return entries.AsReadOnly();
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        FtpWebResponse response = ex.Response as FtpWebResponse;
                        if (response != null)
                        {
                            response.Dispose();
                        }

                        throw new OperationCanceledException(
                            "The FTP directory listing was canceled.", ex, cancellationToken);
                    }

                    throw;
                }
                catch (IOException ex)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw new OperationCanceledException(
                            "The FTP directory listing was canceled.", ex, cancellationToken);
                    }

                    throw;
                }
            }
        }

        internal async Task UploadFileAsync(
            string localFilePath,
            string remoteDirectory,
            string remoteFileName,
            IProgress<FtpTransferProgress> progress,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(localFilePath))
            {
                throw new ArgumentException("A local file is required.", "localFilePath");
            }

            string normalizedDirectory = NormalizeRemoteDirectory(remoteDirectory);
            ValidateRemoteFileName(remoteFileName);
            FileInfo fileInfo = new FileInfo(localFilePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("The staged file no longer exists.", localFilePath);
            }

            await EnsureRemoteDirectoryAsync(remoteDirectory, cancellationToken);
            string remotePath = normalizedDirectory == "/"
                ? "/" + remoteFileName
                : normalizedDirectory.TrimEnd('/') + "/" + remoteFileName;
            FtpWebRequest request = CreateRequest(remotePath, WebRequestMethods.Ftp.UploadFile);

            using (cancellationToken.Register(request.Abort))
            {
                try
                {
                    using (FileStream input = new FileStream(localFilePath, FileMode.Open, FileAccess.Read,
                        FileShare.Read, TransferBufferSize, true))
                    using (Stream output = await request.GetRequestStreamAsync())
                    {
                        byte[] buffer = new byte[TransferBufferSize];
                        long bytesSent = 0;
                        int bytesRead;
                        while ((bytesRead = await input.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                            bytesSent += bytesRead;
                            if (progress != null)
                            {
                                progress.Report(new FtpTransferProgress(bytesSent, input.Length));
                            }
                        }

                        await output.FlushAsync(cancellationToken);
                    }

                    using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                    {
                        if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
                        {
                            throw new WebException(response.StatusDescription);
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw new OperationCanceledException("The FTP upload was canceled.", ex, cancellationToken);
                    }

                    throw;
                }
            }
        }

        private async Task EnsureRemoteDirectoryAsync(string remoteDirectory, CancellationToken cancellationToken)
        {
            string normalizedDirectory = NormalizeRemoteDirectory(remoteDirectory);
            string[] segments = normalizedDirectory.Split(
                new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string currentDirectory = string.Empty;

            foreach (string segment in segments)
            {
                currentDirectory += "/" + segment + "/";
                FtpWebRequest request = CreateRequest(
                    currentDirectory, WebRequestMethods.Ftp.MakeDirectory);

                using (cancellationToken.Register(request.Abort))
                {
                    try
                    {
                        using (FtpWebResponse response =
                            (FtpWebResponse)await request.GetResponseAsync())
                        {
                            if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
                            {
                                throw new WebException(response.StatusDescription);
                            }
                        }
                    }
                    catch (WebException createException)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            FtpWebResponse canceledCreateResponse =
                                createException.Response as FtpWebResponse;
                            if (canceledCreateResponse != null)
                            {
                                canceledCreateResponse.Dispose();
                            }
                            throw new OperationCanceledException(
                                "The FTP directory request was canceled.", createException, cancellationToken);
                        }

                        FtpWebResponse existingDirectoryResponse =
                            createException.Response as FtpWebResponse;
                        bool passCreateFailureToCaller = false;
                        try
                        {
                            await TestDirectoryAsync(currentDirectory, cancellationToken);
                        }
                        catch (WebException directoryTestException)
                        {
                            FtpWebResponse directoryTestResponse =
                                directoryTestException.Response as FtpWebResponse;
                            if (directoryTestResponse != null)
                            {
                                directoryTestResponse.Dispose();
                            }
                            passCreateFailureToCaller = true;
                            throw createException;
                        }
                        finally
                        {
                            if (!passCreateFailureToCaller && existingDirectoryResponse != null)
                            {
                                existingDirectoryResponse.Dispose();
                            }
                        }
                    }
                }
            }
        }

        internal static string NormalizeRemoteDirectory(string remoteDirectory)
        {
            if (string.IsNullOrWhiteSpace(remoteDirectory))
            {
                throw new ArgumentException("Enter the PS3 destination folder, for example /dev_hdd0/game/<TITLE_ID>/USRDIR.");
            }

            string normalized = remoteDirectory.Trim().Replace('\\', '/');
            if (normalized.IndexOfAny(new[] { '?', '#', ':' }) >= 0)
            {
                throw new ArgumentException("The remote folder contains characters that are not valid in an FTP path.");
            }

            string[] segments = normalized.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string segment in segments)
            {
                if (segment == "." || segment == "..")
                {
                    throw new ArgumentException("The remote folder cannot contain '.' or '..' path segments.");
                }
                if (ContainsControlCharacter(segment))
                {
                    throw new ArgumentException("The remote folder cannot contain control characters.");
                }
            }

            return segments.Length == 0 ? "/" : "/" + string.Join("/", segments) + "/";
        }

        internal static void ValidateRemoteFileName(string remoteFileName)
        {
            if (string.IsNullOrWhiteSpace(remoteFileName))
            {
                throw new ArgumentException("Enter a remote file name.");
            }

            if (remoteFileName == "." || remoteFileName == ".."
                || remoteFileName.IndexOfAny(new[] { '/', '\\', ':', '?', '#' }) >= 0
                || ContainsControlCharacter(remoteFileName))
            {
                throw new ArgumentException("Remote file names must be a single file name without path separators or control characters.");
            }
        }

        private FtpWebRequest CreateRequest(string remotePath, string method)
        {
            UriBuilder uriBuilder = new UriBuilder(Uri.UriSchemeFtp, settings.Host, settings.Port)
            {
                Path = remotePath
            };

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uriBuilder.Uri);
            request.Method = method;
            request.Credentials = new NetworkCredential(settings.UserName, settings.Password);
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = false;
            request.Timeout = RequestTimeoutMilliseconds;
            request.ReadWriteTimeout = RequestTimeoutMilliseconds;
            return request;
        }

        private static bool ContainsControlCharacter(string value)
        {
            foreach (char character in value)
            {
                if (char.IsControl(character))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsSuccessfulFtpResponse(FtpStatusCode statusCode)
        {
            int numericStatus = (int)statusCode;
            return numericStatus >= 100 && numericStatus < 300;
        }
    }
}
