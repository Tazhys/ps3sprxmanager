using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EbootExpress
{
    internal sealed class PackageImportData
    {
        internal PackageImportData(string packageDirectory, IList<PackageAsset> assets,
            IList<PackageInstructionDocument> documents)
        {
            PackageDirectory = packageDirectory;
            PackageName = Path.GetFileName(packageDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
            Assets = assets;
            Documents = documents;
        }

        internal string PackageDirectory { get; private set; }
        internal string PackageName { get; private set; }
        internal IList<PackageAsset> Assets { get; private set; }
        internal IList<PackageInstructionDocument> Documents { get; private set; }

        internal string InstructionsText
        {
            get
            {
                if (Documents.Count == 0)
                {
                    return "No readme or instruction text documents were found in this package.";
                }

                StringBuilder text = new StringBuilder();
                text.AppendFormat(CultureInfo.CurrentCulture,
                    "Parsed {0} text document(s). Contents are shown as text only; review the destination suggestions before uploading.",
                    Documents.Count);
                text.AppendLine();
                text.AppendLine();

                foreach (PackageInstructionDocument document in Documents)
                {
                    text.AppendLine("===== " + document.RelativePath + " =====");
                    text.AppendLine(document.Text);
                    text.AppendLine();
                }

                return text.ToString();
            }
        }
    }

    internal sealed class PackageInstructionDocument
    {
        internal PackageInstructionDocument(string path, string relativePath, string text)
        {
            Path = path;
            RelativePath = relativePath;
            Text = text;
        }

        internal string Path { get; private set; }
        internal string RelativePath { get; private set; }
        internal string Text { get; private set; }
    }

    internal sealed class PackageAsset : INotifyPropertyChanged
    {
        private bool include = true;
        private string remoteDirectory;
        private string remoteFileName;
        private long length;

        internal PackageAsset(string path, string relativePath, bool isEboot,
            string remoteDirectory, long length)
        {
            LocalPath = path;
            RelativePath = relativePath;
            IsEboot = isEboot;
            this.remoteDirectory = remoteDirectory;
            this.remoteFileName = isEboot ? "EBOOT.BIN" : Path.GetFileName(path);
            this.length = length;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Include
        {
            get { return include; }
            set
            {
                if (include != value)
                {
                    include = value;
                    OnPropertyChanged("Include");
                }
            }
        }

        public string Type
        {
            get
            {
                return IsEboot ? "EBOOT" :
                    string.Equals(Path.GetExtension(LocalPath), ".sprx", StringComparison.OrdinalIgnoreCase)
                        ? "SPRX MENU"
                        : "SUPPORT";
            }
        }

        public string RelativePath { get; private set; }

        public string RemoteDirectory
        {
            get { return remoteDirectory; }
            set
            {
                if (remoteDirectory != value)
                {
                    remoteDirectory = value;
                    OnPropertyChanged("RemoteDirectory");
                }
            }
        }

        public string RemoteFileName
        {
            get { return remoteFileName; }
            set
            {
                if (remoteFileName != value)
                {
                    remoteFileName = value;
                    OnPropertyChanged("RemoteFileName");
                }
            }
        }

        public string SizeText
        {
            get { return FormatSize(length); }
        }

        internal string LocalPath { get; private set; }
        internal bool IsEboot { get; private set; }
        internal long Length { get { return length; } }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private static string FormatSize(long value)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            double size = value;
            int unitIndex = 0;
            while (size >= 1024 && unitIndex < units.Length - 1)
            {
                size /= 1024;
                unitIndex++;
            }

            return string.Format(CultureInfo.CurrentCulture, "{0:0.##} {1}", size, units[unitIndex]);
        }
    }

    internal static class PackageLibraryReader
    {
        private static readonly Regex RemotePathPattern = new Regex(
            @"(?i)(?:/?dev_hdd0|/?hdd0|/?tmp)(?:/[A-Za-z0-9_.-]+)*",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        internal static PackageImportData LoadPackage(string packageDirectory, string defaultGameDirectory)
        {
            if (string.IsNullOrWhiteSpace(packageDirectory))
            {
                throw new ArgumentException("Select a package folder.", "packageDirectory");
            }

            string fullPackageDirectory = Path.GetFullPath(packageDirectory);
            if (!Directory.Exists(fullPackageDirectory))
            {
                throw new DirectoryNotFoundException("The selected package folder does not exist: " + fullPackageDirectory);
            }

            string rootPrefix = fullPackageDirectory.TrimEnd(
                Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;
            string[] allPaths = Directory.GetFiles(fullPackageDirectory, "*", SearchOption.AllDirectories)
                .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
                .ToArray();
            List<string> documentPaths = allPaths.Where(IsInstructionDocument).ToList();
            List<PackageInstructionDocument> documents = documentPaths
                .Select(path => new PackageInstructionDocument(
                    path,
                    GetRelativePath(rootPrefix, path),
                    File.ReadAllText(path)))
                .ToList();
            HashSet<string> documentPathSet = new HashSet<string>(documentPaths, StringComparer.OrdinalIgnoreCase);
            string[] assetPaths = allPaths.Where(path => !documentPathSet.Contains(path)).ToArray();
            int commonRootLength = GetCommonPackageRootLength(rootPrefix, assetPaths);

            List<PackageAsset> assets = new List<PackageAsset>();
            foreach (string assetPath in assetPaths)
            {
                bool isEboot = string.Equals(Path.GetFileName(assetPath), "EBOOT.BIN", StringComparison.OrdinalIgnoreCase);
                string relativePath = GetRelativePath(rootPrefix, assetPath);
                string relativeDirectory = GetPackageRelativeDirectory(relativePath, commonRootLength);
                string suggestedDirectory = FindInstructionDirectory(documents, assetPath, isEboot);

                if (string.IsNullOrEmpty(suggestedDirectory))
                {
                    suggestedDirectory = isEboot
                        ? NormalizeOptionalGameDirectory(defaultGameDirectory)
                        : "/dev_hdd0/tmp/";
                }

                if (!isEboot && !string.IsNullOrEmpty(relativeDirectory)
                    && DirectoryIsPackageTemporaryRoot(suggestedDirectory)
                    && !InstructionNamesFile(documents, assetPath))
                {
                    suggestedDirectory = AppendRelativeDirectory(suggestedDirectory, relativeDirectory);
                }

                FileInfo fileInfo = new FileInfo(assetPath);
                assets.Add(new PackageAsset(assetPath, relativePath, isEboot, suggestedDirectory, fileInfo.Length));
            }

            if (assets.Count == 0)
            {
                throw new InvalidOperationException("The selected package contains no files to stage.");
            }

            return new PackageImportData(fullPackageDirectory, assets, documents);
        }

        private static bool IsInstructionDocument(string path)
        {
            string extension = Path.GetExtension(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            bool isTextDocument = string.Equals(extension, ".txt", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".text", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".md", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".nfo", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".readme", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".rtf", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".html", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".htm", StringComparison.OrdinalIgnoreCase);

            bool instructionName = fileName.IndexOf("read", StringComparison.OrdinalIgnoreCase) >= 0
                || fileName.IndexOf("instruction", StringComparison.OrdinalIgnoreCase) >= 0
                || fileName.IndexOf("install", StringComparison.OrdinalIgnoreCase) >= 0
                || fileName.IndexOf("guide", StringComparison.OrdinalIgnoreCase) >= 0
                || fileName.IndexOf("tutorial", StringComparison.OrdinalIgnoreCase) >= 0
                || fileName.IndexOf("tut", StringComparison.OrdinalIgnoreCase) >= 0
                || fileName.IndexOf("howto", StringComparison.OrdinalIgnoreCase) >= 0;

            return isTextDocument || instructionName;
        }

        private static int GetCommonPackageRootLength(string rootPrefix, IEnumerable<string> assetPaths)
        {
            List<string[]> directories = assetPaths
                .Select(path => GetRelativePath(rootPrefix, path).Split(
                    new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries).Take(
                        GetRelativePath(rootPrefix, path).Split(
                            new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries).Length - 1).ToArray())
                .ToList();

            if (directories.Count == 0)
            {
                return 0;
            }

            int sharedLength = directories.Min(parts => parts.Length);
            int commonLength = 0;
            while (commonLength < sharedLength)
            {
                string segment = directories[0][commonLength];
                if (directories.Any(parts => !string.Equals(parts[commonLength], segment, StringComparison.OrdinalIgnoreCase)))
                {
                    break;
                }
                commonLength++;
            }

            if (commonLength > 0
                && (string.Equals(directories[0][0], "tmp", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(directories[0][0], "dev_hdd0", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(directories[0][0], "game", StringComparison.OrdinalIgnoreCase)))
            {
                return 0;
            }

            return commonLength;
        }

        private static string GetPackageRelativeDirectory(string relativePath, int commonRootLength)
        {
            string[] segments = relativePath.Split(
                new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
            int directoryLength = Math.Max(0, segments.Length - 1);
            int start = Math.Min(commonRootLength, directoryLength);
            List<string> directorySegments = segments.Skip(start).Take(directoryLength - start).ToList();

            if (directorySegments.Count > 0
                && string.Equals(directorySegments[0], "tmp", StringComparison.OrdinalIgnoreCase))
            {
                directorySegments.RemoveAt(0);
            }

            if (directorySegments.Count > 1
                && string.Equals(directorySegments[0], "dev_hdd0", StringComparison.OrdinalIgnoreCase)
                && string.Equals(directorySegments[1], "tmp", StringComparison.OrdinalIgnoreCase))
            {
                directorySegments.RemoveRange(0, 2);
            }

            return string.Join("/", directorySegments);
        }

        private static string FindInstructionDirectory(
            IEnumerable<PackageInstructionDocument> documents,
            string assetPath,
            bool isEboot)
        {
            string fileName = Path.GetFileName(assetPath);
            bool isSprx = string.Equals(Path.GetExtension(assetPath), ".sprx", StringComparison.OrdinalIgnoreCase);

            foreach (PackageInstructionDocument document in documents)
            {
                foreach (string line in document.Text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None))
                {
                    if (line.IndexOf("????", StringComparison.OrdinalIgnoreCase) >= 0
                        || line.IndexOf("<TITLE", StringComparison.OrdinalIgnoreCase) >= 0
                        || line.IndexOf("[TITLE", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        continue;
                    }

                    bool namesFile = line.IndexOf(fileName, StringComparison.OrdinalIgnoreCase) >= 0;
                    bool namesFileType = isEboot
                        ? line.IndexOf("eboot", StringComparison.OrdinalIgnoreCase) >= 0
                        : isSprx
                            ? line.IndexOf("sprx", StringComparison.OrdinalIgnoreCase) >= 0
                                || line.IndexOf("menu", StringComparison.OrdinalIgnoreCase) >= 0
                            : line.IndexOf(Path.GetExtension(assetPath).TrimStart('.'),
                                StringComparison.OrdinalIgnoreCase) >= 0;
                    if (!namesFile && !namesFileType)
                    {
                        continue;
                    }

                    MatchCollection paths = RemotePathPattern.Matches(line);
                    foreach (Match match in paths)
                    {
                        string directory = ConvertDocumentPathToDirectory(match.Value, fileName);
                        if (string.IsNullOrEmpty(directory))
                        {
                            continue;
                        }

                        if (DirectoryIsGameUsrDirectory(directory))
                        {
                            return directory;
                        }

                        if (!isEboot && DirectoryIsPackageTemporaryRoot(directory))
                        {
                            return directory;
                        }
                    }
                }
            }

            return null;
        }

        private static bool InstructionNamesFile(IEnumerable<PackageInstructionDocument> documents, string assetPath)
        {
            string fileName = Path.GetFileName(assetPath);
            return documents.Any(document =>
                document.Text.IndexOf(fileName, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static string ConvertDocumentPathToDirectory(string path, string fileName)
        {
            string candidate = path.TrimEnd('.', ',', ';', ':', '!', ')', ']', '}', '"', '\'');
            if (candidate.IndexOfAny(new[] { '?', '*' }) >= 0)
            {
                return null;
            }

            if (candidate.StartsWith("/dev_hdd0", StringComparison.OrdinalIgnoreCase))
            {
            }
            else if (candidate.StartsWith("dev_hdd0", StringComparison.OrdinalIgnoreCase))
            {
                candidate = "/" + candidate;
            }
            else if (candidate.StartsWith("/hdd0", StringComparison.OrdinalIgnoreCase))
            {
                candidate = "/dev_hdd0" + candidate.Substring(5);
            }
            else if (candidate.StartsWith("hdd0", StringComparison.OrdinalIgnoreCase))
            {
                candidate = "/dev_hdd0" + candidate.Substring(4);
            }
            else if (candidate.StartsWith("/tmp", StringComparison.OrdinalIgnoreCase))
            {
                candidate = "/dev_hdd0" + candidate;
            }
            else if (candidate.StartsWith("tmp", StringComparison.OrdinalIgnoreCase))
            {
                candidate = "/dev_hdd0/" + candidate;
            }
            else
            {
                return null;
            }

            string lastSegment = candidate.Substring(candidate.LastIndexOf('/') + 1);
            bool pathNamesFile = string.Equals(lastSegment, fileName, StringComparison.OrdinalIgnoreCase)
                || !string.IsNullOrEmpty(Path.GetExtension(lastSegment));
            if (pathNamesFile)
            {
                int separator = candidate.LastIndexOf('/');
                candidate = separator <= 0 ? "/" : candidate.Substring(0, separator);
            }

            try
            {
                return Ps3FtpClient.NormalizeRemoteDirectory(candidate);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private static bool DirectoryIsPackageTemporaryRoot(string directory)
        {
            return string.Equals(directory.TrimEnd('/'), "/dev_hdd0/tmp", StringComparison.OrdinalIgnoreCase);
        }

        private static bool DirectoryIsGameUsrDirectory(string directory)
        {
            return directory.IndexOf("/game/", StringComparison.OrdinalIgnoreCase) >= 0
                && directory.IndexOf("/usrdir/", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string AppendRelativeDirectory(string remoteDirectory, string relativeDirectory)
        {
            string combined = remoteDirectory.TrimEnd('/') + "/" + relativeDirectory.Trim('/');
            return Ps3FtpClient.NormalizeRemoteDirectory(combined);
        }

        private static string NormalizeOptionalGameDirectory(string remoteDirectory)
        {
            if (string.IsNullOrWhiteSpace(remoteDirectory))
            {
                return string.Empty;
            }

            return Ps3FtpClient.NormalizeRemoteDirectory(remoteDirectory);
        }

        private static string GetRelativePath(string rootPrefix, string path)
        {
            return path.Substring(rootPrefix.Length);
        }
    }
}
