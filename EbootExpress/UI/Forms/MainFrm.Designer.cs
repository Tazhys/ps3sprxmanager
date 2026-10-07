using System;
using System.Drawing;
using System.Windows.Forms;

namespace EbootExpress
{
    partial class MainFrm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.connectionGroup = new System.Windows.Forms.Panel();
            this.connectionSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelConnectionHeader = new System.Windows.Forms.Label();
            this.connectionContentPanel = new System.Windows.Forms.Panel();
            this.connectionFieldsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelHost = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textEditHost = new System.Windows.Forms.TextBox();
            this.textEditPort = new System.Windows.Forms.TextBox();
            this.textEditUserName = new System.Windows.Forms.TextBox();
            this.textEditPassword = new System.Windows.Forms.TextBox();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.labelGame = new System.Windows.Forms.Label();
            this.labelRegionCode = new System.Windows.Forms.Label();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.buttonDetectInstalledGames = new System.Windows.Forms.Button();
            this.remoteFolderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelRemoteDirectory = new System.Windows.Forms.Label();
            this.textEditRemoteDirectory = new System.Windows.Forms.TextBox();
            this.labelSecurityNote = new System.Windows.Forms.Label();
            this.filesGroup = new System.Windows.Forms.Panel();
            this.filesSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelFilesHeader = new System.Windows.Forms.Label();
            this.filesBodyLayout = new System.Windows.Forms.TableLayoutPanel();
            this.fileToolbar = new System.Windows.Forms.Panel();
            this.labelFileCount = new System.Windows.Forms.Label();
            this.buttonClearFiles = new System.Windows.Forms.Button();
            this.buttonRemoveSelected = new System.Windows.Forms.Button();
            this.buttonAddSprx = new System.Windows.Forms.Button();
            this.buttonAddEboot = new System.Windows.Forms.Button();
            this.buttonAddPackage = new System.Windows.Forms.Button();
            this.gridFiles = new System.Windows.Forms.DataGridView();
            this.activityGroup = new System.Windows.Forms.Panel();
            this.activitySectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelActivityHeader = new System.Windows.Forms.Label();
            this.memoActivity = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.progressBarUpload = new EbootExpress.ThemedProgressBar();
            this.labelUploadStatus = new System.Windows.Forms.Label();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.connectionGroup.SuspendLayout();
            this.connectionSectionLayout.SuspendLayout();
            this.connectionContentPanel.SuspendLayout();
            this.connectionFieldsLayout.SuspendLayout();
            this.remoteFolderLayout.SuspendLayout();
            this.filesGroup.SuspendLayout();
            this.filesSectionLayout.SuspendLayout();
            this.filesBodyLayout.SuspendLayout();
            this.fileToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).BeginInit();
            this.activityGroup.SuspendLayout();
            this.activitySectionLayout.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(29)))));
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.connectionGroup, 0, 1);
            this.mainLayout.Controls.Add(this.filesGroup, 0, 2);
            this.mainLayout.Controls.Add(this.activityGroup, 0, 3);
            this.mainLayout.Controls.Add(this.footerPanel, 0, 4);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 5;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.mainLayout.Size = new System.Drawing.Size(1084, 720);
            this.mainLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(25)))), ((int)(((byte)(39)))));
            this.headerPanel.Controls.Add(this.pictureBoxLogo);
            this.headerPanel.Controls.Add(this.labelConnectionStatus);
            this.headerPanel.Controls.Add(this.labelSubtitle);
            this.headerPanel.Controls.Add(this.labelTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1084, 76);
            this.headerPanel.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(17, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(68, 68);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConnectionStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(49)))), ((int)(((byte)(27)))));
            this.labelConnectionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(112)))));
            this.labelConnectionStatus.Location = new System.Drawing.Point(880, 27);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(175, 20);
            this.labelConnectionStatus.TabIndex = 2;
            this.labelConnectionStatus.Text = "NOT TESTED";
            this.labelConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelSubtitle.Location = new System.Drawing.Point(101, 43);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(250, 15);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "PS3 EBOOT / SPRX Manager and FTP uploader";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(98, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(187, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "EBOOT EXPRESS";
            // 
            // connectionGroup
            // 
            this.connectionGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.connectionGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionGroup.Controls.Add(this.connectionSectionLayout);
            this.connectionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionGroup.Location = new System.Drawing.Point(3, 79);
            this.connectionGroup.Name = "connectionGroup";
            this.connectionGroup.Size = new System.Drawing.Size(1078, 176);
            this.connectionGroup.TabIndex = 1;
            // 
            // connectionSectionLayout
            // 
            this.connectionSectionLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.connectionSectionLayout.ColumnCount = 1;
            this.connectionSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connectionSectionLayout.Controls.Add(this.labelConnectionHeader, 0, 0);
            this.connectionSectionLayout.Controls.Add(this.connectionContentPanel, 0, 1);
            this.connectionSectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionSectionLayout.Location = new System.Drawing.Point(0, 0);
            this.connectionSectionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.connectionSectionLayout.Name = "connectionSectionLayout";
            this.connectionSectionLayout.RowCount = 2;
            this.connectionSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.connectionSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connectionSectionLayout.Size = new System.Drawing.Size(1076, 174);
            this.connectionSectionLayout.TabIndex = 0;
            // 
            // labelConnectionHeader
            // 
            this.labelConnectionHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.labelConnectionHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelConnectionHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelConnectionHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.labelConnectionHeader.Location = new System.Drawing.Point(0, 0);
            this.labelConnectionHeader.Margin = new System.Windows.Forms.Padding(0);
            this.labelConnectionHeader.Name = "labelConnectionHeader";
            this.labelConnectionHeader.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.labelConnectionHeader.Size = new System.Drawing.Size(1076, 22);
            this.labelConnectionHeader.TabIndex = 0;
            this.labelConnectionHeader.Text = "PS3 FTP CONNECTION";
            this.labelConnectionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // connectionContentPanel
            // 
            this.connectionContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.connectionContentPanel.Controls.Add(this.connectionFieldsLayout);
            this.connectionContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionContentPanel.Location = new System.Drawing.Point(0, 22);
            this.connectionContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.connectionContentPanel.Name = "connectionContentPanel";
            this.connectionContentPanel.Size = new System.Drawing.Size(1076, 152);
            this.connectionContentPanel.TabIndex = 1;
            // 
            // connectionFieldsLayout
            // 
            this.connectionFieldsLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.connectionFieldsLayout.ColumnCount = 5;
            this.connectionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.connectionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.connectionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.connectionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.connectionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.connectionFieldsLayout.Controls.Add(this.labelHost, 0, 0);
            this.connectionFieldsLayout.Controls.Add(this.labelPort, 1, 0);
            this.connectionFieldsLayout.Controls.Add(this.labelUserName, 2, 0);
            this.connectionFieldsLayout.Controls.Add(this.labelPassword, 3, 0);
            this.connectionFieldsLayout.Controls.Add(this.textEditHost, 0, 1);
            this.connectionFieldsLayout.Controls.Add(this.textEditPort, 1, 1);
            this.connectionFieldsLayout.Controls.Add(this.textEditUserName, 2, 1);
            this.connectionFieldsLayout.Controls.Add(this.textEditPassword, 3, 1);
            this.connectionFieldsLayout.Controls.Add(this.buttonTestConnection, 4, 1);
            this.connectionFieldsLayout.Controls.Add(this.labelGame, 0, 2);
            this.connectionFieldsLayout.Controls.Add(this.labelRegionCode, 1, 2);
            this.connectionFieldsLayout.Controls.Add(this.comboBoxGame, 0, 3);
            this.connectionFieldsLayout.Controls.Add(this.comboBoxRegion, 1, 3);
            this.connectionFieldsLayout.Controls.Add(this.buttonDetectInstalledGames, 4, 3);
            this.connectionFieldsLayout.Controls.Add(this.remoteFolderLayout, 0, 4);
            this.connectionFieldsLayout.Controls.Add(this.labelSecurityNote, 0, 5);
            this.connectionFieldsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionFieldsLayout.Location = new System.Drawing.Point(0, 0);
            this.connectionFieldsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.connectionFieldsLayout.Name = "connectionFieldsLayout";
            this.connectionFieldsLayout.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.connectionFieldsLayout.RowCount = 6;
            this.connectionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.connectionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.connectionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.connectionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.connectionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.connectionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.connectionFieldsLayout.Size = new System.Drawing.Size(1076, 152);
            this.connectionFieldsLayout.TabIndex = 0;
            // 
            // labelHost
            // 
            this.labelHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelHost.Location = new System.Drawing.Point(11, 4);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(290, 18);
            this.labelHost.TabIndex = 0;
            this.labelHost.Text = "Host / IP";
            this.labelHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPort
            // 
            this.labelPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelPort.Location = new System.Drawing.Point(307, 4);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(100, 18);
            this.labelPort.TabIndex = 0;
            this.labelPort.Text = "Port";
            this.labelPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUserName
            // 
            this.labelUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelUserName.Location = new System.Drawing.Point(413, 4);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(206, 18);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Username";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPassword
            // 
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelPassword.Location = new System.Drawing.Point(625, 4);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(259, 18);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEditHost
            // 
            this.textEditHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.textEditHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditHost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.textEditHost.Location = new System.Drawing.Point(11, 24);
            this.textEditHost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditHost.Name = "textEditHost";
            this.textEditHost.Size = new System.Drawing.Size(290, 23);
            this.textEditHost.TabIndex = 0;
            this.textEditHost.TextChanged += new System.EventHandler(this.connectionSettings_EditValueChanged);
            // 
            // textEditPort
            // 
            this.textEditPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.textEditPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.textEditPort.Location = new System.Drawing.Point(307, 24);
            this.textEditPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditPort.Name = "textEditPort";
            this.textEditPort.Size = new System.Drawing.Size(100, 23);
            this.textEditPort.TabIndex = 2;
            this.textEditPort.Text = "21";
            this.textEditPort.TextChanged += new System.EventHandler(this.connectionSettings_EditValueChanged);
            // 
            // textEditUserName
            // 
            this.textEditUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.textEditUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.textEditUserName.Location = new System.Drawing.Point(413, 24);
            this.textEditUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditUserName.Name = "textEditUserName";
            this.textEditUserName.Size = new System.Drawing.Size(206, 23);
            this.textEditUserName.TabIndex = 4;
            this.textEditUserName.Text = "anonymous";
            this.textEditUserName.TextChanged += new System.EventHandler(this.connectionSettings_EditValueChanged);
            // 
            // textEditPassword
            // 
            this.textEditPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.textEditPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.textEditPassword.Location = new System.Drawing.Point(625, 24);
            this.textEditPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditPassword.Name = "textEditPassword";
            this.textEditPassword.Size = new System.Drawing.Size(259, 23);
            this.textEditPassword.TabIndex = 6;
            this.textEditPassword.UseSystemPasswordChar = true;
            this.textEditPassword.TextChanged += new System.EventHandler(this.connectionSettings_EditValueChanged);
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.buttonTestConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTestConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.buttonTestConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(66)))));
            this.buttonTestConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(78)))));
            this.buttonTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTestConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.buttonTestConnection.Location = new System.Drawing.Point(890, 23);
            this.buttonTestConnection.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(175, 25);
            this.buttonTestConnection.TabIndex = 7;
            this.buttonTestConnection.Text = "Test connection";
            this.buttonTestConnection.UseVisualStyleBackColor = false;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // labelGame
            // 
            this.labelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelGame.Location = new System.Drawing.Point(11, 49);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(290, 18);
            this.labelGame.TabIndex = 0;
            this.labelGame.Text = "Game";
            this.labelGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRegionCode
            // 
            this.connectionFieldsLayout.SetColumnSpan(this.labelRegionCode, 3);
            this.labelRegionCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRegionCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelRegionCode.Location = new System.Drawing.Point(307, 49);
            this.labelRegionCode.Name = "labelRegionCode";
            this.labelRegionCode.Size = new System.Drawing.Size(577, 18);
            this.labelRegionCode.TabIndex = 0;
            this.labelRegionCode.Text = "Region / code";
            this.labelRegionCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.comboBoxGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Items.AddRange(new object[] {
            "Select a game"});
            this.comboBoxGame.Location = new System.Drawing.Point(11, 68);
            this.comboBoxGame.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(290, 23);
            this.comboBoxGame.TabIndex = 8;
            this.comboBoxGame.SelectedIndexChanged += new System.EventHandler(this.comboBoxGame_SelectedIndexChanged);
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.connectionFieldsLayout.SetColumnSpan(this.comboBoxRegion, 3);
            this.comboBoxRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Items.AddRange(new object[] {
            "Select a code"});
            this.comboBoxRegion.Location = new System.Drawing.Point(307, 68);
            this.comboBoxRegion.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(577, 23);
            this.comboBoxRegion.TabIndex = 9;
            this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
            // 
            // buttonDetectInstalledGames
            // 
            this.buttonDetectInstalledGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.buttonDetectInstalledGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDetectInstalledGames.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.buttonDetectInstalledGames.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(66)))));
            this.buttonDetectInstalledGames.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(78)))));
            this.buttonDetectInstalledGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDetectInstalledGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.buttonDetectInstalledGames.Location = new System.Drawing.Point(890, 68);
            this.buttonDetectInstalledGames.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.buttonDetectInstalledGames.Name = "buttonDetectInstalledGames";
            this.buttonDetectInstalledGames.Size = new System.Drawing.Size(175, 25);
            this.buttonDetectInstalledGames.TabIndex = 10;
            this.buttonDetectInstalledGames.Text = "Detect installed games";
            this.buttonDetectInstalledGames.UseVisualStyleBackColor = false;
            this.buttonDetectInstalledGames.Click += new System.EventHandler(this.buttonDetectInstalledGames_Click);
            // 
            // remoteFolderLayout
            // 
            this.remoteFolderLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.remoteFolderLayout.ColumnCount = 2;
            this.connectionFieldsLayout.SetColumnSpan(this.remoteFolderLayout, 5);
            this.remoteFolderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.remoteFolderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.remoteFolderLayout.Controls.Add(this.labelRemoteDirectory, 0, 0);
            this.remoteFolderLayout.Controls.Add(this.textEditRemoteDirectory, 1, 0);
            this.remoteFolderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteFolderLayout.Location = new System.Drawing.Point(8, 94);
            this.remoteFolderLayout.Margin = new System.Windows.Forms.Padding(0);
            this.remoteFolderLayout.Name = "remoteFolderLayout";
            this.remoteFolderLayout.RowCount = 1;
            this.remoteFolderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.remoteFolderLayout.Size = new System.Drawing.Size(1060, 27);
            this.remoteFolderLayout.TabIndex = 0;
            // 
            // labelRemoteDirectory
            // 
            this.labelRemoteDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRemoteDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelRemoteDirectory.Location = new System.Drawing.Point(3, 0);
            this.labelRemoteDirectory.Name = "labelRemoteDirectory";
            this.labelRemoteDirectory.Size = new System.Drawing.Size(104, 27);
            this.labelRemoteDirectory.TabIndex = 0;
            this.labelRemoteDirectory.Text = "Remote folder";
            this.labelRemoteDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEditRemoteDirectory
            // 
            this.textEditRemoteDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.textEditRemoteDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditRemoteDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditRemoteDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.textEditRemoteDirectory.Location = new System.Drawing.Point(113, 2);
            this.textEditRemoteDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditRemoteDirectory.Name = "textEditRemoteDirectory";
            this.textEditRemoteDirectory.Size = new System.Drawing.Size(944, 23);
            this.textEditRemoteDirectory.TabIndex = 11;
            this.textEditRemoteDirectory.TextChanged += new System.EventHandler(this.connectionSettings_EditValueChanged);
            // 
            // labelSecurityNote
            // 
            this.connectionFieldsLayout.SetColumnSpan(this.labelSecurityNote, 5);
            this.labelSecurityNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSecurityNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelSecurityNote.Location = new System.Drawing.Point(11, 121);
            this.labelSecurityNote.Name = "labelSecurityNote";
            this.labelSecurityNote.Size = new System.Drawing.Size(1054, 27);
            this.labelSecurityNote.TabIndex = 0;
            this.labelSecurityNote.Text = "Select a game code to fill its standard game folder, or enter a remote folder man" +
    "ually. FTP is unencrypted.";
            this.labelSecurityNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filesGroup
            // 
            this.filesGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.filesGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesGroup.Controls.Add(this.filesSectionLayout);
            this.filesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesGroup.Location = new System.Drawing.Point(3, 261);
            this.filesGroup.Name = "filesGroup";
            this.filesGroup.Size = new System.Drawing.Size(1078, 282);
            this.filesGroup.TabIndex = 2;
            // 
            // filesSectionLayout
            // 
            this.filesSectionLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.filesSectionLayout.ColumnCount = 1;
            this.filesSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filesSectionLayout.Controls.Add(this.labelFilesHeader, 0, 0);
            this.filesSectionLayout.Controls.Add(this.filesBodyLayout, 0, 1);
            this.filesSectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesSectionLayout.Location = new System.Drawing.Point(0, 0);
            this.filesSectionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.filesSectionLayout.Name = "filesSectionLayout";
            this.filesSectionLayout.RowCount = 2;
            this.filesSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.filesSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filesSectionLayout.Size = new System.Drawing.Size(1076, 280);
            this.filesSectionLayout.TabIndex = 0;
            // 
            // labelFilesHeader
            // 
            this.labelFilesHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.labelFilesHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFilesHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelFilesHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.labelFilesHeader.Location = new System.Drawing.Point(0, 0);
            this.labelFilesHeader.Margin = new System.Windows.Forms.Padding(0);
            this.labelFilesHeader.Name = "labelFilesHeader";
            this.labelFilesHeader.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.labelFilesHeader.Size = new System.Drawing.Size(1076, 22);
            this.labelFilesHeader.TabIndex = 0;
            this.labelFilesHeader.Text = "STAGED FILES";
            this.labelFilesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filesBodyLayout
            // 
            this.filesBodyLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.filesBodyLayout.ColumnCount = 1;
            this.filesBodyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filesBodyLayout.Controls.Add(this.fileToolbar, 0, 0);
            this.filesBodyLayout.Controls.Add(this.gridFiles, 0, 1);
            this.filesBodyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesBodyLayout.Location = new System.Drawing.Point(0, 22);
            this.filesBodyLayout.Margin = new System.Windows.Forms.Padding(0);
            this.filesBodyLayout.Name = "filesBodyLayout";
            this.filesBodyLayout.RowCount = 2;
            this.filesBodyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.filesBodyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filesBodyLayout.Size = new System.Drawing.Size(1076, 258);
            this.filesBodyLayout.TabIndex = 1;
            // 
            // fileToolbar
            // 
            this.fileToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.fileToolbar.Controls.Add(this.labelFileCount);
            this.fileToolbar.Controls.Add(this.buttonClearFiles);
            this.fileToolbar.Controls.Add(this.buttonRemoveSelected);
            this.fileToolbar.Controls.Add(this.buttonAddSprx);
            this.fileToolbar.Controls.Add(this.buttonAddEboot);
            this.fileToolbar.Controls.Add(this.buttonAddPackage);
            this.fileToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileToolbar.Location = new System.Drawing.Point(3, 3);
            this.fileToolbar.Name = "fileToolbar";
            this.fileToolbar.Size = new System.Drawing.Size(1070, 37);
            this.fileToolbar.TabIndex = 0;
            // 
            // labelFileCount
            // 
            this.labelFileCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.labelFileCount.Location = new System.Drawing.Point(865, 12);
            this.labelFileCount.Name = "labelFileCount";
            this.labelFileCount.Size = new System.Drawing.Size(190, 15);
            this.labelFileCount.TabIndex = 5;
            this.labelFileCount.Text = "0 FILES STAGED";
            this.labelFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonClearFiles
            // 
            this.buttonClearFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.buttonClearFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.buttonClearFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.buttonClearFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.buttonClearFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(155)))), ((int)(((byte)(162)))));
            this.buttonClearFiles.Location = new System.Drawing.Point(374, 5);
            this.buttonClearFiles.Name = "buttonClearFiles";
            this.buttonClearFiles.Size = new System.Drawing.Size(105, 28);
            this.buttonClearFiles.TabIndex = 4;
            this.buttonClearFiles.Text = "Clear list";
            this.buttonClearFiles.UseVisualStyleBackColor = false;
            this.buttonClearFiles.Click += new System.EventHandler(this.buttonClearFiles_Click);
            // 
            // buttonRemoveSelected
            // 
            this.buttonRemoveSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.buttonRemoveSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.buttonRemoveSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(40)))), ((int)(((byte)(52)))));
            this.buttonRemoveSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.buttonRemoveSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(155)))), ((int)(((byte)(162)))));
            this.buttonRemoveSelected.Location = new System.Drawing.Point(258, 5);
            this.buttonRemoveSelected.Name = "buttonRemoveSelected";
            this.buttonRemoveSelected.Size = new System.Drawing.Size(110, 28);
            this.buttonRemoveSelected.TabIndex = 3;
            this.buttonRemoveSelected.Text = "Remove selected";
            this.buttonRemoveSelected.UseVisualStyleBackColor = false;
            this.buttonRemoveSelected.Click += new System.EventHandler(this.buttonRemoveSelected_Click);
            // 
            // buttonAddSprx
            // 
            this.buttonAddSprx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.buttonAddSprx.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.buttonAddSprx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(66)))));
            this.buttonAddSprx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(78)))));
            this.buttonAddSprx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSprx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.buttonAddSprx.Location = new System.Drawing.Point(137, 5);
            this.buttonAddSprx.Name = "buttonAddSprx";
            this.buttonAddSprx.Size = new System.Drawing.Size(115, 28);
            this.buttonAddSprx.TabIndex = 2;
            this.buttonAddSprx.Text = "Add SPRX menu";
            this.buttonAddSprx.UseVisualStyleBackColor = false;
            this.buttonAddSprx.Click += new System.EventHandler(this.buttonAddSprx_Click);
            // 
            // buttonAddEboot
            // 
            this.buttonAddEboot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.buttonAddEboot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.buttonAddEboot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(66)))));
            this.buttonAddEboot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(78)))));
            this.buttonAddEboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddEboot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.buttonAddEboot.Location = new System.Drawing.Point(17, 5);
            this.buttonAddEboot.Name = "buttonAddEboot";
            this.buttonAddEboot.Size = new System.Drawing.Size(114, 28);
            this.buttonAddEboot.TabIndex = 1;
            this.buttonAddEboot.Text = "Add EBOOT.BIN";
            this.buttonAddEboot.UseVisualStyleBackColor = false;
            this.buttonAddEboot.Click += new System.EventHandler(this.buttonAddEboot_Click);
            // 
            // buttonAddPackage
            // 
            this.buttonAddPackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
            this.buttonAddPackage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.buttonAddPackage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(66)))));
            this.buttonAddPackage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(78)))));
            this.buttonAddPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.buttonAddPackage.Location = new System.Drawing.Point(485, 5);
            this.buttonAddPackage.Name = "buttonAddPackage";
            this.buttonAddPackage.Size = new System.Drawing.Size(126, 28);
            this.buttonAddPackage.TabIndex = 0;
            this.buttonAddPackage.Text = "Import package...";
            this.buttonAddPackage.UseVisualStyleBackColor = false;
            this.buttonAddPackage.Click += new System.EventHandler(this.buttonAddPackage_Click);
            // 
            // gridFiles
            // 
            this.gridFiles.AllowUserToAddRows = false;
            this.gridFiles.AllowUserToDeleteRows = false;
            this.gridFiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gridFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.gridFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridFiles.ColumnHeadersHeight = 30;
            this.gridFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFiles.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFiles.EnableHeadersVisualStyles = false;
            this.gridFiles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.gridFiles.Location = new System.Drawing.Point(3, 46);
            this.gridFiles.Name = "gridFiles";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridFiles.RowHeadersVisible = false;
            this.gridFiles.RowTemplate.Height = 27;
            this.gridFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFiles.Size = new System.Drawing.Size(1070, 209);
            this.gridFiles.TabIndex = 1;
            this.gridFiles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridFiles_CellBeginEdit);
            // 
            // activityGroup
            // 
            this.activityGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.activityGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activityGroup.Controls.Add(this.activitySectionLayout);
            this.activityGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activityGroup.Location = new System.Drawing.Point(3, 549);
            this.activityGroup.Name = "activityGroup";
            this.activityGroup.Size = new System.Drawing.Size(1078, 110);
            this.activityGroup.TabIndex = 3;
            // 
            // activitySectionLayout
            // 
            this.activitySectionLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.activitySectionLayout.ColumnCount = 1;
            this.activitySectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.activitySectionLayout.Controls.Add(this.labelActivityHeader, 0, 0);
            this.activitySectionLayout.Controls.Add(this.memoActivity, 0, 1);
            this.activitySectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activitySectionLayout.Location = new System.Drawing.Point(0, 0);
            this.activitySectionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.activitySectionLayout.Name = "activitySectionLayout";
            this.activitySectionLayout.RowCount = 2;
            this.activitySectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.activitySectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.activitySectionLayout.Size = new System.Drawing.Size(1076, 108);
            this.activitySectionLayout.TabIndex = 0;
            // 
            // labelActivityHeader
            // 
            this.labelActivityHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.labelActivityHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelActivityHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelActivityHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.labelActivityHeader.Location = new System.Drawing.Point(0, 0);
            this.labelActivityHeader.Margin = new System.Windows.Forms.Padding(0);
            this.labelActivityHeader.Name = "labelActivityHeader";
            this.labelActivityHeader.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.labelActivityHeader.Size = new System.Drawing.Size(1076, 22);
            this.labelActivityHeader.TabIndex = 0;
            this.labelActivityHeader.Text = "ACTIVITY";
            this.labelActivityHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memoActivity
            // 
            this.memoActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.memoActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memoActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoActivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.memoActivity.Location = new System.Drawing.Point(3, 25);
            this.memoActivity.Multiline = true;
            this.memoActivity.Name = "memoActivity";
            this.memoActivity.ReadOnly = true;
            this.memoActivity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memoActivity.Size = new System.Drawing.Size(1070, 80);
            this.memoActivity.TabIndex = 1;
            this.memoActivity.WordWrap = false;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(29)))));
            this.footerPanel.Controls.Add(this.progressBarUpload);
            this.footerPanel.Controls.Add(this.labelUploadStatus);
            this.footerPanel.Controls.Add(this.buttonUpload);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerPanel.Location = new System.Drawing.Point(0, 662);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1084, 58);
            this.footerPanel.TabIndex = 4;
            // 
            // progressBarUpload
            // 
            this.progressBarUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarUpload.BackColor = System.Drawing.Color.Transparent;
            this.progressBarUpload.Location = new System.Drawing.Point(329, 18);
            this.progressBarUpload.Name = "progressBarUpload";
            this.progressBarUpload.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(211)))), ((int)(((byte)(193)))));
            this.progressBarUpload.ProgressTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.progressBarUpload.Size = new System.Drawing.Size(538, 20);
            this.progressBarUpload.TabIndex = 2;
            this.progressBarUpload.TrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            // 
            // labelUploadStatus
            // 
            this.labelUploadStatus.AutoSize = true;
            this.labelUploadStatus.Location = new System.Drawing.Point(17, 21);
            this.labelUploadStatus.Name = "labelUploadStatus";
            this.labelUploadStatus.Size = new System.Drawing.Size(93, 15);
            this.labelUploadStatus.TabIndex = 1;
            this.labelUploadStatus.Text = "Ready to upload";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(211)))), ((int)(((byte)(193)))));
            this.buttonUpload.Enabled = false;
            this.buttonUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(211)))), ((int)(((byte)(193)))));
            this.buttonUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(153)))));
            this.buttonUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(226)))), ((int)(((byte)(207)))));
            this.buttonUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonUpload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.buttonUpload.Location = new System.Drawing.Point(884, 13);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(171, 30);
            this.buttonUpload.TabIndex = 0;
            this.buttonUpload.Text = "Upload staged files";
            this.buttonUpload.UseVisualStyleBackColor = false;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1084, 720);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.MinimumSize = new System.Drawing.Size(1100, 640);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EBOOT EXPRESS - PS3 SPRX Manager";
            this.mainLayout.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.connectionGroup.ResumeLayout(false);
            this.connectionSectionLayout.ResumeLayout(false);
            this.connectionContentPanel.ResumeLayout(false);
            this.connectionFieldsLayout.ResumeLayout(false);
            this.connectionFieldsLayout.PerformLayout();
            this.remoteFolderLayout.ResumeLayout(false);
            this.remoteFolderLayout.PerformLayout();
            this.filesGroup.ResumeLayout(false);
            this.filesSectionLayout.ResumeLayout(false);
            this.filesBodyLayout.ResumeLayout(false);
            this.fileToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).EndInit();
            this.activityGroup.ResumeLayout(false);
            this.activitySectionLayout.ResumeLayout(false);
            this.activitySectionLayout.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel connectionGroup;
        private System.Windows.Forms.TableLayoutPanel connectionSectionLayout;
        private System.Windows.Forms.Label labelConnectionHeader;
        private System.Windows.Forms.Panel connectionContentPanel;
        private System.Windows.Forms.TableLayoutPanel connectionFieldsLayout;
        private System.Windows.Forms.TableLayoutPanel remoteFolderLayout;
        private System.Windows.Forms.Label labelSecurityNote;
        private System.Windows.Forms.TextBox textEditRemoteDirectory;
        private System.Windows.Forms.Label labelRemoteDirectory;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label labelRegionCode;
        private System.Windows.Forms.ComboBox comboBoxGame;
        private System.Windows.Forms.Label labelGame;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.Button buttonDetectInstalledGames;
        private System.Windows.Forms.TextBox textEditPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textEditUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textEditPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textEditHost;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Panel filesGroup;
        private System.Windows.Forms.TableLayoutPanel filesSectionLayout;
        private System.Windows.Forms.Label labelFilesHeader;
        private System.Windows.Forms.TableLayoutPanel filesBodyLayout;
        private System.Windows.Forms.DataGridView gridFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemoteDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemoteFileName;
        private System.Windows.Forms.Panel fileToolbar;
        private System.Windows.Forms.Label labelFileCount;
        private System.Windows.Forms.Button buttonClearFiles;
        private System.Windows.Forms.Button buttonRemoveSelected;
        private System.Windows.Forms.Button buttonAddSprx;
        private System.Windows.Forms.Button buttonAddEboot;
        private System.Windows.Forms.Button buttonAddPackage;
        private System.Windows.Forms.Panel activityGroup;
        private System.Windows.Forms.TableLayoutPanel activitySectionLayout;
        private System.Windows.Forms.Label labelActivityHeader;
        private System.Windows.Forms.TextBox memoActivity;
        private System.Windows.Forms.Panel footerPanel;
        private EbootExpress.ThemedProgressBar progressBarUpload;
        private System.Windows.Forms.Label labelUploadStatus;
        private System.Windows.Forms.Button buttonUpload;
    }
}
