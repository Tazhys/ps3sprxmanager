
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbootExpress
{
    public partial class MainFrm : Form
    {
        private readonly BindingList<StagedFile> stagedFiles = new BindingList<StagedFile>();
        private CancellationTokenSource uploadCancellation;
        private IList<GameRegionPreset> selectedRegionPresets = new List<GameRegionPreset>();
        private string selectedPresetRemoteDirectory;
        private bool connectionTestInProgress;
        private bool updatingRegionSelectors;

        public MainFrm()
        {
            InitializeComponent();
            WinFormsTheme.EnableDarkTitleBar(this);
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            using (Stream logoStream = typeof(MainFrm).Assembly.GetManifestResourceStream(
                "EbootExpress.Assets.EbootExpressLogo.png"))
            {
                if (logoStream == null)
                {
                    throw new InvalidOperationException("The embedded EBOOT EXPRESS logo could not be found.");
                }

                using (System.Drawing.Image logo = System.Drawing.Image.FromStream(logoStream))
                {
                    pictureBoxLogo.Image = new System.Drawing.Bitmap(logo);
                }
            }

            updatingRegionSelectors = true;
            comboBoxGame.Items.AddRange(GameRegionCatalog.Games);
            comboBoxGame.SelectedIndex = 0;
            comboBoxRegion.SelectedIndex = 0;
            updatingRegionSelectors = false;
            gridFiles.DataSource = stagedFiles;
            stagedFiles.ListChanged += StagedFiles_ListChanged;
            UpdateStagedFileCount();
            AppendActivity("Ready. Stage EBOOT/SPRX files or import a local package and review its instructions.");
        }

        private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingRegionSelectors)
            {
                return;
            }

            if (!string.IsNullOrEmpty(selectedPresetRemoteDirectory)
                && string.Equals(textEditRemoteDirectory.Text, selectedPresetRemoteDirectory, StringComparison.OrdinalIgnoreCase))
            {
                textEditRemoteDirectory.Text = string.Empty;
            }
            selectedPresetRemoteDirectory = null;

            updatingRegionSelectors = true;
            try
            {
                selectedRegionPresets = comboBoxGame.SelectedIndex > 0
                    ? GameRegionCatalog.GetPresetsForGame(comboBoxGame.Text)
                    : new List<GameRegionPreset>();
                comboBoxRegion.BeginUpdate();
                try
                {
                    comboBoxRegion.Items.Clear();
                    comboBoxRegion.Items.Add("Select a code");
                    foreach (GameRegionPreset preset in selectedRegionPresets)
                    {
                        comboBoxRegion.Items.Add(preset.DisplayText);
                    }
                    comboBoxRegion.SelectedIndex = 0;
                }
                finally
                {
                    comboBoxRegion.EndUpdate();
                }
            }
            finally
            {
                updatingRegionSelectors = false;
            }

            if (selectedRegionPresets.Count > 0)
            {
                AppendActivity("Selected " + comboBoxGame.Text + ". Choose a title or package code to set its game folder.");
            }
        }

        private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingRegionSelectors)
            {
                return;
            }

            int selectedIndex = comboBoxRegion.SelectedIndex;
            if (selectedIndex <= 0 || selectedIndex > selectedRegionPresets.Count)
            {
                return;
            }

            GameRegionPreset preset = selectedRegionPresets[selectedIndex - 1];
            selectedPresetRemoteDirectory = "/dev_hdd0/game/" + preset.TitleId + "/USRDIR";
            textEditRemoteDirectory.Text = selectedPresetRemoteDirectory;
            AppendActivity(string.Format(CultureInfo.CurrentCulture,
                "Selected {0} code {1}; destination is /dev_hdd0/game/{2}/USRDIR.",
                preset.Game, preset.Code, preset.TitleId));
        }

        private void buttonAddEboot_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select an EBOOT binary";
                dialog.Filter = "EBOOT binaries (*.bin)|*.bin|All files (*.*)|*.*";
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                string error;
                if (TryStageFile(dialog.FileName, true, out error))
                {
                    AppendActivity("Staged EBOOT.BIN from " + dialog.FileName);
                }
                else
                {
                    MessageBox.Show(this, error, "Unable to stage EBOOT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonAddSprx_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select SPRX menu files";
                dialog.Filter = "SPRX files (*.sprx)|*.sprx|All files (*.*)|*.*";
                dialog.CheckFileExists = true;
                dialog.Multiselect = true;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                int added = 0;
                foreach (string filePath in dialog.FileNames)
                {
                    string error;
                    if (TryStageFile(filePath, false, out error))
                    {
                        added++;
                        AppendActivity("Staged SPRX menu " + Path.GetFileName(filePath));
                    }
                    else
                    {
                        AppendActivity("Skipped " + filePath + ": " + error);
                    }
                }

                if (added == 0 && dialog.FileNames.Length > 0)
                {
                    MessageBox.Show(this, "None of the selected files could be staged. See the activity log for details.",
                        "Unable to stage SPRX files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            List<StagedFile> selectedFiles = gridFiles.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => row.DataBoundItem as StagedFile)
                .Where(file => file != null)
                .ToList();

            foreach (StagedFile file in selectedFiles)
            {
                stagedFiles.Remove(file);
                AppendActivity("Removed " + file.RemoteFileName + " from the staging list.");
            }
        }

        private void buttonClearFiles_Click(object sender, EventArgs e)
        {
            if (stagedFiles.Count == 0)
            {
                return;
            }

            stagedFiles.Clear();
            AppendActivity("Cleared the staging list.");
        }

        private void buttonAddPackage_Click(object sender, EventArgs e)
        {
            string defaultPackageDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads", "SPRXManager", "Games");
            if (comboBoxGame.SelectedIndex > 0)
            {
                string selectedGameDirectory = Path.Combine(defaultPackageDirectory, comboBoxGame.Text);
                if (Directory.Exists(selectedGameDirectory))
                {
                    defaultPackageDirectory = selectedGameDirectory;
                }
            }
            if (!Directory.Exists(defaultPackageDirectory))
            {
                defaultPackageDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select one extracted package folder. The package files stay in this local folder; only staged selections are uploaded.";
                dialog.ShowNewFolderButton = false;
                dialog.SelectedPath = defaultPackageDirectory;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                string selectedPackageDirectory = Path.GetFullPath(dialog.SelectedPath);
                string folderName = Path.GetFileName(selectedPackageDirectory.TrimEnd(
                    Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                string rootDirectory = Path.GetPathRoot(selectedPackageDirectory);
                bool selectedDriveRoot = !string.IsNullOrEmpty(rootDirectory)
                    && string.Equals(
                        selectedPackageDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                        rootDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                        StringComparison.OrdinalIgnoreCase);
                if (selectedDriveRoot
                    || string.Equals(folderName, "Games", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(folderName, "MW2", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(folderName, "MW3", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(folderName, "BO2", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(this,
                        "Choose an individual package folder inside the game folder, not the Games, MW2, MW3, or BO2 library folder.",
                        "Select one package", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    PackageImportData package = PackageLibraryReader.LoadPackage(
                        selectedPackageDirectory, textEditRemoteDirectory.Text);

                    using (PackageImportForm form = new PackageImportForm(package))
                    {
                        if (form.ShowDialog(this) != DialogResult.OK)
                        {
                            return;
                        }

                        int stagedCount = 0;
                        List<string> skippedFiles = new List<string>();
                        foreach (PackageAsset asset in form.SelectedAssets)
                        {
                            string error;
                            if (TryStagePackageAsset(asset, out error))
                            {
                                stagedCount++;
                            }
                            else
                            {
                                skippedFiles.Add(asset.RelativePath + ": " + error);
                            }
                        }

                        AppendActivity(string.Format(CultureInfo.CurrentCulture,
                            "Imported {0} file(s) from {1}; parsed {2} read/instruction document(s).",
                            stagedCount, package.PackageName, package.Documents.Count));

                        if (skippedFiles.Count > 0)
                        {
                            MessageBox.Show(this,
                                "Some files could not be staged:\r\n\r\n" + string.Join("\r\n", skippedFiles),
                                "Package import was partial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, "Invalid package folder or destination",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show(this, ex.Message, "Package folder not found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(this, ex.Message, "Package file not found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(this, ex.Message, "Package folder access denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Security.SecurityException ex)
                {
                    MessageBox.Show(this, ex.Message, "Package folder access denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, ex.Message, "Unable to read package",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(this, ex.Message, "Unable to import package",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void connectionSettings_EditValueChanged(object sender, EventArgs e)
        {
            if (uploadCancellation == null)
            {
                SetConnectionStatus("NOT TESTED", System.Drawing.Color.DarkOrange);
            }
        }

        private async void buttonDetectInstalledGames_Click(object sender, EventArgs e)
        {
            if (uploadCancellation != null || connectionTestInProgress)
            {
                return;
            }

            FtpConnectionSettings settings;
            try
            {
                settings = ReadConnectionSettings();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Check FTP settings",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            connectionTestInProgress = true;
            buttonTestConnection.Enabled = false;
            buttonUpload.Enabled = false;
            SetConnectionInputsEnabled(false);
            SetConnectionStatus("SCANNING...", System.Drawing.Color.DarkOrange);
            labelUploadStatus.Text = "Scanning /dev_hdd0/game/...";
            AppendActivity("Scanning PS3 game folders at " + settings.Host + ":" + settings.Port
                + "/dev_hdd0/game/...");

            try
            {
                Ps3FtpClient client = new Ps3FtpClient(settings);
                IList<string> directoryEntries = await client.ListDirectoryAsync(
                    "/dev_hdd0/game/", CancellationToken.None);
                IList<GameRegionPreset> detectedPresets =
                    GameRegionCatalog.FindInstalledPresets(directoryEntries);

                AppendActivity(string.Format(CultureInfo.CurrentCulture,
                    "Scanned {0} folder entr{1}; found {2} supported game region(s).",
                    directoryEntries.Count, directoryEntries.Count == 1 ? "y" : "ies",
                    detectedPresets.Count));

                if (detectedPresets.Count == 0)
                {
                    SetConnectionStatus("NO MATCHES", System.Drawing.Color.DarkOrange);
                    labelUploadStatus.Text = "No supported game regions found";
                    MessageBox.Show(this,
                        "No MW2, MW3, or BO2 title folders from the current region catalog were found under /dev_hdd0/game/.",
                        "No supported games detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                GameRegionPreset detectedPreset = null;
                if (detectedPresets.Count == 1)
                {
                    detectedPreset = detectedPresets[0];
                }
                else
                {
                    GameRegionPreset preferredPreset = GetSelectedRegionPreset();
                    using (InstalledGamesForm form = new InstalledGamesForm(detectedPresets, preferredPreset))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            detectedPreset = form.SelectedPreset;
                        }
                    }
                }

                if (detectedPreset == null)
                {
                    SetConnectionStatus("READY", System.Drawing.Color.SeaGreen);
                    labelUploadStatus.Text = "Detected regions; no region selected";
                    AppendActivity("Installed-region selection was canceled; existing game selection was left unchanged.");
                    return;
                }

                ApplyDetectedPreset(detectedPreset);
                SetConnectionStatus("READY", System.Drawing.Color.SeaGreen);
                labelUploadStatus.Text = "Detected " + detectedPreset.Game + " " + detectedPreset.Code;
                AppendActivity(string.Format(CultureInfo.CurrentCulture,
                    "Auto-detected {0} region {1} in /dev_hdd0/game/{2}/.",
                    detectedPreset.Game, detectedPreset.Code, detectedPreset.TitleId));
            }
            catch (WebException ex)
            {
                string message = DescribeFtpError(ex);
                SetConnectionStatus("SCAN FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "Unable to scan game folders";
                AppendActivity("Game-folder scan failed: " + message);
                MessageBox.Show(this, message, "Game detection failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                SetConnectionStatus("SCAN FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "FTP settings are invalid";
                AppendActivity("Game-folder scan settings are invalid: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Game detection failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IOException ex)
            {
                SetConnectionStatus("SCAN FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "Unable to read game-folder listing";
                AppendActivity("Could not read the PS3 game-folder listing: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Game detection failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                SetConnectionStatus("SCAN FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "Game detection failed";
                AppendActivity("Game detection failed: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Game detection failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connectionTestInProgress = false;
                SetConnectionInputsEnabled(true);
                buttonTestConnection.Enabled = true;
                UpdateUploadButton();
            }
        }

        private GameRegionPreset GetSelectedRegionPreset()
        {
            int selectedIndex = comboBoxRegion.SelectedIndex;
            return selectedIndex > 0 && selectedIndex <= selectedRegionPresets.Count
                ? selectedRegionPresets[selectedIndex - 1]
                : null;
        }

        private void ApplyDetectedPreset(GameRegionPreset detectedPreset)
        {
            int gameIndex = comboBoxGame.Items.IndexOf(detectedPreset.Game);
            if (gameIndex < 0)
            {
                throw new InvalidOperationException(
                    "The detected game is not available in the game selector: " + detectedPreset.Game);
            }

            comboBoxGame.SelectedIndex = gameIndex;
            int regionIndex = selectedRegionPresets.ToList().FindIndex(preset =>
                string.Equals(preset.Game, detectedPreset.Game, StringComparison.OrdinalIgnoreCase)
                && string.Equals(preset.TitleId, detectedPreset.TitleId, StringComparison.OrdinalIgnoreCase)
                && string.Equals(preset.Code, detectedPreset.Code, StringComparison.OrdinalIgnoreCase));
            if (regionIndex < 0)
            {
                throw new InvalidOperationException(
                    "The detected region is not available in the region selector: " + detectedPreset.TitleId);
            }

            comboBoxRegion.SelectedIndex = regionIndex + 1;
        }

        private async void buttonTestConnection_Click(object sender, EventArgs e)
        {
            if (uploadCancellation != null || connectionTestInProgress)
            {
                return;
            }

            FtpConnectionSettings settings;
            string remoteDirectory;
            try
            {
                settings = ReadConnectionSettings();
                remoteDirectory = Ps3FtpClient.NormalizeRemoteDirectory(textEditRemoteDirectory.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Check FTP settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Check FTP settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            connectionTestInProgress = true;
            buttonTestConnection.Enabled = false;
            buttonUpload.Enabled = false;
            SetConnectionInputsEnabled(false);
            SetConnectionStatus("TESTING...", System.Drawing.Color.DarkOrange);
            labelUploadStatus.Text = "Checking FTP directory...";
            AppendActivity("Testing FTP access to " + settings.Host + ":" + settings.Port + remoteDirectory);

            try
            {
                Ps3FtpClient client = new Ps3FtpClient(settings);
                await client.TestDirectoryAsync(remoteDirectory, CancellationToken.None);
                SetConnectionStatus("READY", System.Drawing.Color.SeaGreen);
                labelUploadStatus.Text = "FTP directory is accessible";
                AppendActivity("FTP connection and remote directory test succeeded.");
            }
            catch (WebException ex)
            {
                string message = DescribeFtpError(ex);
                SetConnectionStatus("CONNECTION FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "FTP connection failed";
                AppendActivity("FTP connection failed: " + message);
                MessageBox.Show(this, message, "FTP connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                SetConnectionStatus("CONNECTION FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "FTP settings are invalid";
                AppendActivity("FTP settings are invalid: " + ex.Message);
                MessageBox.Show(this, ex.Message, "FTP connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                SetConnectionStatus("CONNECTION FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "FTP request could not be started";
                AppendActivity("FTP request failed: " + ex.Message);
                MessageBox.Show(this, ex.Message, "FTP connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connectionTestInProgress = false;
                SetConnectionInputsEnabled(true);
                buttonTestConnection.Enabled = true;
                UpdateUploadButton();
            }
        }

        private async void buttonUpload_Click(object sender, EventArgs e)
        {
            if (uploadCancellation != null)
            {
                uploadCancellation.Cancel();
                buttonUpload.Enabled = false;
                labelUploadStatus.Text = "Canceling upload...";
                return;
            }
            if (connectionTestInProgress)
            {
                return;
            }

            FtpConnectionSettings settings;
            List<StagedFile> files;
            try
            {
                settings = ReadConnectionSettings();
                files = GetFilesToUpload();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Check upload settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Check upload settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, ex.Message, "Unable to read staged file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(this, ex.Message, "Unable to read staged file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string destinationSummary = string.Join(Environment.NewLine,
                files.Select(file => "  " + file.RemoteDirectory + file.RemoteFileName));
            DialogResult confirmation = MessageBox.Show(this,
                string.Format(CultureInfo.CurrentCulture,
                    "Upload {0} file(s) to {1}:{2} at these destinations?\r\n{3}\r\n\r\nFiles with the same names on the PS3 may be overwritten.",
                    files.Count, settings.Host, settings.Port, destinationSummary),
                "Confirm PS3 upload", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            long totalBytes;
            try
            {
                totalBytes = files.Sum(file => file.Length);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(this, ex.Message, "Total upload size is too large", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            uploadCancellation = new CancellationTokenSource();
            CancellationTokenSource uploadOperation = uploadCancellation;
            CancellationToken token = uploadOperation.Token;
            SetUploadInProgress(true);
            progressBarUpload.Value = 0;
            labelUploadStatus.Text = "Starting upload...";

            long completedBytes = 0;
            string currentFileName = null;
            Ps3FtpClient ftpClient = new Ps3FtpClient(settings);

            try
            {
                foreach (StagedFile file in files)
                {
                    token.ThrowIfCancellationRequested();
                    currentFileName = file.RemoteFileName;
                    AppendActivity("Uploading " + file.RemoteDirectory + file.RemoteFileName + "...");

                    IProgress<FtpTransferProgress> progress = new Progress<FtpTransferProgress>(transfer =>
                    {
                        if (!ReferenceEquals(uploadCancellation, uploadOperation) || token.IsCancellationRequested)
                        {
                            return;
                        }

                        double sent = completedBytes + transfer.BytesSent;
                        int percent = totalBytes == 0 ? 0 : (int)Math.Min(99, sent * 100.0 / totalBytes);
                        progressBarUpload.Value = percent;
                        labelUploadStatus.Text = string.Format(CultureInfo.CurrentCulture,
                            "Uploading {0} ({1}%)", file.RemoteFileName, percent);
                    });

                    await ftpClient.UploadFileAsync(file.LocalPath, file.RemoteDirectory,
                        file.RemoteFileName, progress, token);
                    completedBytes += file.Length;
                    int completedPercent = totalBytes == 0 ? 100 :
                        (int)Math.Min(100, completedBytes * 100.0 / totalBytes);
                    progressBarUpload.Value = completedPercent;
                    labelUploadStatus.Text = string.Format(CultureInfo.CurrentCulture,
                        "Uploaded {0} ({1}%)", file.RemoteFileName, completedPercent);
                    AppendActivity("Uploaded " + file.RemoteDirectory + file.RemoteFileName + " successfully.");
                }

                SetConnectionStatus("READY", System.Drawing.Color.SeaGreen);
                labelUploadStatus.Text = "Upload complete";
                AppendActivity("All staged files were uploaded successfully.");
            }
            catch (OperationCanceledException)
            {
                labelUploadStatus.Text = "Upload canceled";
                AppendActivity("Upload canceled by the user.");
            }
            catch (WebException ex)
            {
                string message = DescribeFtpError(ex);
                SetConnectionStatus("UPLOAD FAILED", System.Drawing.Color.Firebrick);
                labelUploadStatus.Text = "Upload failed";
                AppendActivity("Upload failed for " + (currentFileName ?? "staged file") + ": " + message);
                MessageBox.Show(this,
                    "Upload failed for " + (currentFileName ?? "staged file") + ".\r\n\r\n" + message,
                    "FTP upload failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                labelUploadStatus.Text = "Upload failed";
                AppendActivity("File transfer failed for " + (currentFileName ?? "staged file") + ": " + ex.Message);
                MessageBox.Show(this, ex.Message, "File transfer failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                labelUploadStatus.Text = "Upload failed";
                AppendActivity("File access failed for " + (currentFileName ?? "staged file") + ": " + ex.Message);
                MessageBox.Show(this, ex.Message, "File access failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                labelUploadStatus.Text = "Upload failed";
                AppendActivity("Upload settings are invalid: " + ex.Message);
                MessageBox.Show(this, ex.Message, "FTP upload failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                labelUploadStatus.Text = "Upload failed";
                AppendActivity("FTP upload failed: " + ex.Message);
                MessageBox.Show(this, ex.Message, "FTP upload failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                uploadCancellation.Dispose();
                uploadCancellation = null;
                SetUploadInProgress(false);
            }
        }

        private void gridFiles_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colRemoteFileName.Index)
            {
                StagedFile selectedFile = gridFiles.Rows[e.RowIndex].DataBoundItem as StagedFile;
                if (selectedFile != null && selectedFile.IsEboot)
                {
                    e.Cancel = true;
                }
            }
        }

        private void StagedFiles_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateStagedFileCount();
        }

        private bool TryStageFile(string filePath, bool isEboot, out string error)
        {
            error = null;
            try
            {
                string expectedExtension = isEboot ? ".bin" : ".sprx";
                if (!string.Equals(Path.GetExtension(filePath), expectedExtension, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Select a " + expectedExtension + " file.");
                }

                PackageAsset asset = new PackageAsset(filePath, Path.GetFileName(filePath),
                    isEboot, textEditRemoteDirectory.Text, 0);
                return TryStagePackageAsset(asset, out error);
            }
            catch (ArgumentException ex)
            {
                error = ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                error = ex.Message;
            }
            catch (IOException ex)
            {
                error = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                error = ex.Message;
            }
            catch (System.Security.SecurityException ex)
            {
                error = ex.Message;
            }

            return false;
        }

        private bool TryStagePackageAsset(PackageAsset asset, out string error)
        {
            error = null;
            try
            {
                if (asset == null)
                {
                    throw new ArgumentNullException("asset");
                }

                string expectedExtension = asset.IsEboot ? ".bin" : null;
                if (expectedExtension != null
                    && !string.Equals(Path.GetExtension(asset.LocalPath), expectedExtension,
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("EBOOT files must use the .bin extension.");
                }

                string remoteFileName = asset.IsEboot ? "EBOOT.BIN" : (asset.RemoteFileName ?? string.Empty).Trim();
                Ps3FtpClient.ValidateRemoteFileName(remoteFileName);
                if (string.Equals(Path.GetExtension(asset.LocalPath), ".sprx", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(Path.GetExtension(remoteFileName), ".sprx", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("SPRX menu files must keep the .sprx extension.");
                }

                string remoteDirectory = string.IsNullOrWhiteSpace(asset.RemoteDirectory)
                    ? string.Empty
                    : Ps3FtpClient.NormalizeRemoteDirectory(asset.RemoteDirectory);
                string remoteTargetKey = GetRemoteTargetKey(remoteDirectory, remoteFileName);
                if (stagedFiles.Any(file => string.Equals(
                    GetRemoteTargetKey(file.RemoteDirectory, file.RemoteFileName),
                    remoteTargetKey, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidOperationException("A file is already staged for " +
                        remoteDirectory + remoteFileName + ".");
                }

                FileInfo fileInfo = new FileInfo(asset.LocalPath);
                if (!fileInfo.Exists)
                {
                    throw new FileNotFoundException("The selected package file no longer exists.", asset.LocalPath);
                }

                stagedFiles.Add(new StagedFile(asset.LocalPath, asset.IsEboot,
                    remoteDirectory, remoteFileName, fileInfo.Length));
                return true;
            }
            catch (ArgumentException ex)
            {
                error = ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                error = ex.Message;
            }
            catch (IOException ex)
            {
                error = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                error = ex.Message;
            }
            catch (System.Security.SecurityException ex)
            {
                error = ex.Message;
            }

            return false;
        }

        private static string GetRemoteTargetKey(string remoteDirectory, string remoteFileName)
        {
            return (remoteDirectory ?? string.Empty).Trim().TrimEnd('/', '\\').Replace('\\', '/')
                + "/" + (remoteFileName ?? string.Empty).Trim();
        }

        private FtpConnectionSettings ReadConnectionSettings()
        {
            int port;
            if (!int.TryParse(textEditPort.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out port)
                || port < 1 || port > 65535)
            {
                throw new ArgumentException("Enter a valid FTP port between 1 and 65535.");
            }

            return new FtpConnectionSettings(
                textEditHost.Text.Trim(),
                port,
                textEditUserName.Text.Trim(),
                textEditPassword.Text);
        }

        private List<StagedFile> GetFilesToUpload()
        {
            gridFiles.EndEdit();

            if (stagedFiles.Count == 0)
            {
                throw new InvalidOperationException("Add at least one EBOOT.BIN, SPRX, or package file before uploading.");
            }

            HashSet<string> remoteTargets = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            List<StagedFile> files = stagedFiles.ToList();
            foreach (StagedFile file in files)
            {
                FileInfo fileInfo = new FileInfo(file.LocalPath);
                if (!fileInfo.Exists)
                {
                    throw new FileNotFoundException("A staged file no longer exists: " + file.LocalPath, file.LocalPath);
                }

                string remoteFileName = (file.RemoteFileName ?? string.Empty).Trim();
                Ps3FtpClient.ValidateRemoteFileName(remoteFileName);
                if (file.IsEboot && !string.Equals(remoteFileName, "EBOOT.BIN", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("EBOOT files must be uploaded as EBOOT.BIN.");
                }
                if (file.IsSprx && !string.Equals(Path.GetExtension(remoteFileName), ".sprx", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("SPRX menu files must keep the .sprx extension.");
                }
                string remoteDirectory = Ps3FtpClient.NormalizeRemoteDirectory(
                    string.IsNullOrWhiteSpace(file.RemoteDirectory)
                        ? textEditRemoteDirectory.Text
                        : file.RemoteDirectory);
                string remoteTargetKey = GetRemoteTargetKey(remoteDirectory, remoteFileName);
                if (!remoteTargets.Add(remoteTargetKey))
                {
                    throw new InvalidOperationException("The remote destination " +
                        remoteDirectory + remoteFileName + " is used more than once.");
                }

                file.RemoteDirectory = remoteDirectory;
                file.RemoteFileName = remoteFileName;
                file.UpdateLength(fileInfo.Length);
            }

            return files;
        }

        private void SetUploadInProgress(bool uploading)
        {
            SetConnectionInputsEnabled(!uploading);
            buttonTestConnection.Enabled = !uploading;
            buttonAddEboot.Enabled = !uploading;
            buttonAddSprx.Enabled = !uploading;
            buttonAddPackage.Enabled = !uploading;
            buttonRemoveSelected.Enabled = !uploading;
            buttonClearFiles.Enabled = !uploading;
            gridFiles.Enabled = !uploading;
            buttonUpload.Text = uploading ? "Cancel upload" : "Upload staged files";
            buttonUpload.Enabled = uploading || stagedFiles.Count > 0;
        }

        private void SetConnectionInputsEnabled(bool enabled)
        {
            textEditHost.Enabled = enabled;
            textEditPort.Enabled = enabled;
            textEditUserName.Enabled = enabled;
            textEditPassword.Enabled = enabled;
            textEditRemoteDirectory.Enabled = enabled;
            comboBoxGame.Enabled = enabled;
            comboBoxRegion.Enabled = enabled;
            buttonDetectInstalledGames.Enabled = enabled;
        }

        private void UpdateStagedFileCount()
        {
            labelFileCount.Text = string.Format(CultureInfo.CurrentCulture, "{0} FILE{1} STAGED",
                stagedFiles.Count, stagedFiles.Count == 1 ? string.Empty : "S");
            UpdateUploadButton();
        }

        private void UpdateUploadButton()
        {
            if (uploadCancellation == null && !connectionTestInProgress)
            {
                buttonUpload.Enabled = stagedFiles.Count > 0;
            }
        }

        private void SetConnectionStatus(string text, System.Drawing.Color color)
        {
            WinFormsTheme.SetStatus(labelConnectionStatus, text, color);
        }

        private void AppendActivity(string message)
        {
            string entry = string.Format(CultureInfo.CurrentCulture, "[{0:HH:mm:ss}] {1}",
                DateTime.Now, message);
            if (memoActivity.TextLength > 0)
            {
                memoActivity.AppendText(Environment.NewLine);
            }
            memoActivity.AppendText(entry);
            memoActivity.SelectionStart = memoActivity.TextLength;
            memoActivity.ScrollToCaret();
        }

        private static string DescribeFtpError(WebException exception)
        {
            using (FtpWebResponse response = exception.Response as FtpWebResponse)
            {
                if (response != null)
                {
                    return string.Format(CultureInfo.CurrentCulture, "FTP {0}: {1}",
                        (int)response.StatusCode, (response.StatusDescription ?? string.Empty).Trim());
                }
            }

            return exception.Message;
        }
    }

    internal sealed class StagedFile : INotifyPropertyChanged
    {
        private string remoteDirectory;
        private string remoteFileName;
        private long length;

        internal StagedFile(string localPath, bool isEboot, string remoteDirectory,
            string remoteFileName, long length)
        {
            LocalPath = localPath;
            IsEboot = isEboot;
            this.remoteDirectory = remoteDirectory;
            this.remoteFileName = remoteFileName;
            this.length = length;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Type
        {
            get { return IsEboot ? "EBOOT" : IsSprx ? "SPRX MENU" : "SUPPORT FILE"; }
        }

        public string FileName
        {
            get { return Path.GetFileName(LocalPath); }
        }

        public string SizeText
        {
            get { return FormatSize(length); }
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

        internal string LocalPath { get; private set; }
        internal bool IsEboot { get; private set; }
        internal bool IsSprx
        {
            get { return string.Equals(Path.GetExtension(LocalPath), ".sprx", StringComparison.OrdinalIgnoreCase); }
        }
        internal long Length { get { return length; } }

        internal void UpdateLength(long value)
        {
            if (length != value)
            {
                length = value;
                OnPropertyChanged("SizeText");
            }
        }

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
}
