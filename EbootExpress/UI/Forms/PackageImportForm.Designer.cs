using System;
using System.Drawing;
using System.Windows.Forms;

namespace EbootExpress
{
    partial class PackageImportForm
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.labelInstructionsSummary = new System.Windows.Forms.Label();
            this.labelPackagePath = new System.Windows.Forms.Label();
            this.labelPackageTitle = new System.Windows.Forms.Label();
            this.filesGroup = new System.Windows.Forms.Panel();
            this.filesSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelFilesHeader = new System.Windows.Forms.Label();
            this.gridPackage = new System.Windows.Forms.DataGridView();
            this.colInclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemoteDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemoteFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructionsGroup = new System.Windows.Forms.Panel();
            this.instructionsSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelInstructionsHeader = new System.Windows.Forms.Label();
            this.memoInstructions = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddSelected = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.filesGroup.SuspendLayout();
            this.filesSectionLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackage)).BeginInit();
            this.instructionsGroup.SuspendLayout();
            this.instructionsSectionLayout.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.filesGroup, 0, 1);
            this.mainLayout.Controls.Add(this.instructionsGroup, 0, 2);
            this.mainLayout.Controls.Add(this.footerPanel, 0, 3);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(9);
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.mainLayout.Size = new System.Drawing.Size(901, 619);
            this.mainLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.labelInstructionsSummary);
            this.headerPanel.Controls.Add(this.labelPackagePath);
            this.headerPanel.Controls.Add(this.labelPackageTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(12, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(877, 61);
            this.headerPanel.TabIndex = 0;
            // 
            // labelInstructionsSummary
            // 
            this.labelInstructionsSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInstructionsSummary.ForeColor = System.Drawing.Color.FromArgb(150, 167, 188);
            this.labelInstructionsSummary.Location = new System.Drawing.Point(350, 6);
            this.labelInstructionsSummary.Name = "labelInstructionsSummary";
            this.labelInstructionsSummary.Size = new System.Drawing.Size(512, 50);
            this.labelInstructionsSummary.TabIndex = 2;
            this.labelInstructionsSummary.Text = "Package contents and parsed instructions";
            this.labelInstructionsSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPackagePath
            // 
            this.labelPackagePath.AutoEllipsis = true;
            this.labelPackagePath.ForeColor = System.Drawing.Color.FromArgb(150, 167, 188);
            this.labelPackagePath.Location = new System.Drawing.Point(15, 42);
            this.labelPackagePath.Name = "labelPackagePath";
            this.labelPackagePath.Size = new System.Drawing.Size(650, 15);
            this.labelPackagePath.TabIndex = 1;
            this.labelPackagePath.Text = "Package path";
            // 
            // labelPackageTitle
            // 
            this.labelPackageTitle.AutoSize = true;
            this.labelPackageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelPackageTitle.Location = new System.Drawing.Point(13, 6);
            this.labelPackageTitle.Name = "labelPackageTitle";
            this.labelPackageTitle.Size = new System.Drawing.Size(163, 30);
            this.labelPackageTitle.TabIndex = 0;
            this.labelPackageTitle.Text = "Package name";
            // 
            // filesGroup
            // 
            this.filesGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesGroup.Controls.Add(this.filesSectionLayout);
            this.filesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesGroup.Location = new System.Drawing.Point(12, 79);
            this.filesGroup.Name = "filesGroup";
            this.filesGroup.Size = new System.Drawing.Size(877, 278);
            this.filesGroup.TabIndex = 1;
            // 
            // filesSectionLayout
            // 
            this.filesSectionLayout.ColumnCount = 1;
            this.filesSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filesSectionLayout.Controls.Add(this.labelFilesHeader, 0, 0);
            this.filesSectionLayout.Controls.Add(this.gridPackage, 0, 1);
            this.filesSectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesSectionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.filesSectionLayout.Name = "filesSectionLayout";
            this.filesSectionLayout.RowCount = 2;
            this.filesSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.filesSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filesSectionLayout.TabIndex = 0;
            // 
            // labelFilesHeader
            // 
            this.labelFilesHeader.BackColor = System.Drawing.Color.FromArgb(31, 47, 67);
            this.labelFilesHeader.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.labelFilesHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFilesHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelFilesHeader.Location = new System.Drawing.Point(0, 0);
            this.labelFilesHeader.Margin = new System.Windows.Forms.Padding(0);
            this.labelFilesHeader.Name = "labelFilesHeader";
            this.labelFilesHeader.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.labelFilesHeader.Size = new System.Drawing.Size(875, 22);
            this.labelFilesHeader.TabIndex = 0;
            this.labelFilesHeader.Text = "PACKAGE FILES - UNCHECK ANY FILES YOU DO NOT WANT TO STAGE";
            this.labelFilesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridPackage
            // 
            this.gridPackage.AllowUserToAddRows = false;
            this.gridPackage.AllowUserToDeleteRows = false;
            this.gridPackage.AllowUserToResizeRows = false;
            this.gridPackage.AutoGenerateColumns = false;
            this.gridPackage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.gridPackage.BackgroundColor = System.Drawing.Color.FromArgb(13, 22, 35);
            this.gridPackage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPackage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridPackage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridPackage.ColumnHeadersHeight = 30;
            this.gridPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridPackage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInclude,
            this.colType,
            this.colPackageFile,
            this.colPackageSize,
            this.colRemoteDirectory,
            this.colRemoteFileName});
            this.gridPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPackage.EnableHeadersVisualStyles = false;
            this.gridPackage.GridColor = System.Drawing.Color.FromArgb(46, 63, 84);
            this.gridPackage.Location = new System.Drawing.Point(3, 25);
            this.gridPackage.MultiSelect = false;
            this.gridPackage.Name = "gridPackage";
            this.gridPackage.RowHeadersVisible = false;
            this.gridPackage.RowTemplate.Height = 27;
            this.gridPackage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPackage.Size = new System.Drawing.Size(869, 247);
            this.gridPackage.TabIndex = 1;
            this.gridPackage.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridPackage_CellBeginEdit);
            this.gridPackage.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridPackage_CurrentCellDirtyStateChanged);
            // 
            // colInclude
            // 
            this.colInclude.DataPropertyName = "Include";
            this.colInclude.HeaderText = "STAGE";
            this.colInclude.Name = "colInclude";
            this.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInclude.Width = 47;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "TYPE";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colType.Width = 77;
            // 
            // colPackageFile
            // 
            this.colPackageFile.DataPropertyName = "RelativePath";
            this.colPackageFile.HeaderText = "PACKAGE FILE";
            this.colPackageFile.Name = "colPackageFile";
            this.colPackageFile.ReadOnly = true;
            this.colPackageFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPackageFile.Width = 240;
            // 
            // colPackageSize
            // 
            this.colPackageSize.DataPropertyName = "SizeText";
            this.colPackageSize.HeaderText = "SIZE";
            this.colPackageSize.Name = "colPackageSize";
            this.colPackageSize.ReadOnly = true;
            this.colPackageSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPackageSize.Width = 69;
            // 
            // colRemoteDirectory
            // 
            this.colRemoteDirectory.DataPropertyName = "RemoteDirectory";
            this.colRemoteDirectory.HeaderText = "SUGGESTED PS3 FOLDER";
            this.colRemoteDirectory.Name = "colRemoteDirectory";
            this.colRemoteDirectory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemoteDirectory.Width = 257;
            // 
            // colRemoteFileName
            // 
            this.colRemoteFileName.DataPropertyName = "RemoteFileName";
            this.colRemoteFileName.HeaderText = "REMOTE FILE NAME";
            this.colRemoteFileName.Name = "colRemoteFileName";
            this.colRemoteFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemoteFileName.Width = 154;
            // 
            // instructionsGroup
            // 
            this.instructionsGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.instructionsGroup.Controls.Add(this.instructionsSectionLayout);
            this.instructionsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionsGroup.Location = new System.Drawing.Point(12, 363);
            this.instructionsGroup.Name = "instructionsGroup";
            this.instructionsGroup.Size = new System.Drawing.Size(877, 200);
            this.instructionsGroup.TabIndex = 2;
            // 
            // instructionsSectionLayout
            // 
            this.instructionsSectionLayout.ColumnCount = 1;
            this.instructionsSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.instructionsSectionLayout.Controls.Add(this.labelInstructionsHeader, 0, 0);
            this.instructionsSectionLayout.Controls.Add(this.memoInstructions, 0, 1);
            this.instructionsSectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionsSectionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.instructionsSectionLayout.Name = "instructionsSectionLayout";
            this.instructionsSectionLayout.RowCount = 2;
            this.instructionsSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.instructionsSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.instructionsSectionLayout.TabIndex = 0;
            // 
            // labelInstructionsHeader
            // 
            this.labelInstructionsHeader.BackColor = System.Drawing.Color.FromArgb(31, 47, 67);
            this.labelInstructionsHeader.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.labelInstructionsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstructionsHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelInstructionsHeader.Location = new System.Drawing.Point(0, 0);
            this.labelInstructionsHeader.Margin = new System.Windows.Forms.Padding(0);
            this.labelInstructionsHeader.Name = "labelInstructionsHeader";
            this.labelInstructionsHeader.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.labelInstructionsHeader.Size = new System.Drawing.Size(875, 22);
            this.labelInstructionsHeader.TabIndex = 0;
            this.labelInstructionsHeader.Text = "READMES AND INSTRUCTIONS - PARSED AS PLAIN TEXT";
            this.labelInstructionsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memoInstructions
            // 
            this.memoInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoInstructions.Location = new System.Drawing.Point(3, 25);
            this.memoInstructions.Margin = new System.Windows.Forms.Padding(3);
            this.memoInstructions.Multiline = true;
            this.memoInstructions.Name = "memoInstructions";
            this.memoInstructions.ReadOnly = true;
            this.memoInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.memoInstructions.Size = new System.Drawing.Size(869, 170);
            this.memoInstructions.TabIndex = 1;
            this.memoInstructions.WordWrap = false;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.buttonCancel);
            this.footerPanel.Controls.Add(this.buttonAddSelected);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerPanel.Location = new System.Drawing.Point(12, 569);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(877, 38);
            this.footerPanel.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(669, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 26);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonAddSelected
            // 
            this.buttonAddSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddSelected.Location = new System.Drawing.Point(769, 7);
            this.buttonAddSelected.Name = "buttonAddSelected";
            this.buttonAddSelected.Size = new System.Drawing.Size(93, 26);
            this.buttonAddSelected.TabIndex = 0;
            this.buttonAddSelected.Text = "Stage selected";
            this.buttonAddSelected.UseVisualStyleBackColor = false;
            this.buttonAddSelected.Click += new System.EventHandler(this.buttonAddSelected_Click);
            // 
            // PackageImportForm
            // 
            this.AcceptButton = this.buttonAddSelected;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(901, 619);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(814, 572);
            this.Name = "PackageImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EBOOT EXPRESS - Import package";
            this.BackColor = System.Drawing.Color.FromArgb(12, 18, 29);
            this.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.mainLayout.BackColor = System.Drawing.Color.FromArgb(12, 18, 29);
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(15, 25, 39);
            this.filesGroup.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.filesSectionLayout.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.instructionsGroup.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.instructionsSectionLayout.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(12, 18, 29);
            this.memoInstructions.BackColor = System.Drawing.Color.FromArgb(13, 22, 35);
            this.memoInstructions.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.memoInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPackage.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.gridPackage.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridPackage.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.gridPackage.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridPackage.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 79, 94);
            this.gridPackage.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gridPackage.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.gridPackage.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(17, 27, 41);
            this.gridPackage.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridPackage.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 79, 94);
            this.gridPackage.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gridPackage.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 47, 67);
            this.gridPackage.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridPackage.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(31, 47, 67);
            this.gridPackage.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridPackage.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridPackage.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(26, 39, 57);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.buttonCancel.FlatAppearance.BorderSize = 1;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(46, 63, 84);
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 57, 78);
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(33, 48, 66);
            this.buttonAddSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSelected.BackColor = System.Drawing.Color.FromArgb(42, 211, 193);
            this.buttonAddSelected.ForeColor = System.Drawing.Color.FromArgb(7, 24, 33);
            this.buttonAddSelected.FlatAppearance.BorderSize = 1;
            this.buttonAddSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 211, 193);
            this.buttonAddSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(68, 226, 207);
            this.buttonAddSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(27, 166, 153);
            this.buttonAddSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mainLayout.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.filesGroup.ResumeLayout(false);
            this.filesSectionLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPackage)).EndInit();
            this.instructionsGroup.ResumeLayout(false);
            this.instructionsSectionLayout.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label labelInstructionsSummary;
        private System.Windows.Forms.Label labelPackagePath;
        private System.Windows.Forms.Label labelPackageTitle;
        private System.Windows.Forms.Panel filesGroup;
        private System.Windows.Forms.TableLayoutPanel filesSectionLayout;
        private System.Windows.Forms.Label labelFilesHeader;
        private System.Windows.Forms.DataGridView gridPackage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemoteDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemoteFileName;
        private System.Windows.Forms.Panel instructionsGroup;
        private System.Windows.Forms.TableLayoutPanel instructionsSectionLayout;
        private System.Windows.Forms.Label labelInstructionsHeader;
        private System.Windows.Forms.TextBox memoInstructions;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddSelected;
    }
}
