using System;
using System.Drawing;
using System.Windows.Forms;

namespace EbootExpress
{
    partial class InstalledGamesForm
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
            this.labelSummary = new System.Windows.Forms.Label();
            this.gridInstalled = new System.Windows.Forms.DataGridView();
            this.colGame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUseSelected = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInstalled)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.labelSummary, 0, 0);
            this.mainLayout.Controls.Add(this.gridInstalled, 0, 1);
            this.mainLayout.Controls.Add(this.footerPanel, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(12);
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.mainLayout.Size = new System.Drawing.Size(680, 430);
            this.mainLayout.TabIndex = 0;
            // 
            // labelSummary
            // 
            this.labelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSummary.ForeColor = System.Drawing.Color.FromArgb(150, 167, 188);
            this.labelSummary.Location = new System.Drawing.Point(15, 15);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(650, 36);
            this.labelSummary.TabIndex = 0;
            this.labelSummary.Text = "Supported installed games";
            this.labelSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridInstalled
            // 
            this.gridInstalled.AllowUserToAddRows = false;
            this.gridInstalled.AllowUserToDeleteRows = false;
            this.gridInstalled.AllowUserToResizeRows = false;
            this.gridInstalled.AutoGenerateColumns = false;
            this.gridInstalled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInstalled.BackgroundColor = System.Drawing.Color.FromArgb(13, 22, 35);
            this.gridInstalled.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInstalled.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridInstalled.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridInstalled.ColumnHeadersHeight = 30;
            this.gridInstalled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridInstalled.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGame,
            this.colRegionCode,
            this.colTitleId});
            this.gridInstalled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInstalled.EnableHeadersVisualStyles = false;
            this.gridInstalled.GridColor = System.Drawing.Color.FromArgb(46, 63, 84);
            this.gridInstalled.Location = new System.Drawing.Point(15, 57);
            this.gridInstalled.MultiSelect = false;
            this.gridInstalled.Name = "gridInstalled";
            this.gridInstalled.ReadOnly = true;
            this.gridInstalled.RowHeadersVisible = false;
            this.gridInstalled.RowTemplate.Height = 27;
            this.gridInstalled.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInstalled.Size = new System.Drawing.Size(650, 298);
            this.gridInstalled.TabIndex = 1;
            // 
            // colGame
            // 
            this.colGame.DataPropertyName = "Game";
            this.colGame.FillWeight = 150F;
            this.colGame.HeaderText = "GAME";
            this.colGame.Name = "colGame";
            this.colGame.ReadOnly = true;
            this.colGame.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRegionCode
            // 
            this.colRegionCode.DataPropertyName = "Code";
            this.colRegionCode.FillWeight = 230F;
            this.colRegionCode.HeaderText = "REGION / TITLE CODE";
            this.colRegionCode.Name = "colRegionCode";
            this.colRegionCode.ReadOnly = true;
            this.colRegionCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTitleId
            // 
            this.colTitleId.DataPropertyName = "TitleId";
            this.colTitleId.FillWeight = 220F;
            this.colTitleId.HeaderText = "INSTALLED FOLDER";
            this.colTitleId.Name = "colTitleId";
            this.colTitleId.ReadOnly = true;
            this.colTitleId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.buttonCancel);
            this.footerPanel.Controls.Add(this.buttonUseSelected);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerPanel.Location = new System.Drawing.Point(15, 361);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(650, 54);
            this.footerPanel.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(415, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 30);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonUseSelected
            // 
            this.buttonUseSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUseSelected.Location = new System.Drawing.Point(532, 12);
            this.buttonUseSelected.Name = "buttonUseSelected";
            this.buttonUseSelected.Size = new System.Drawing.Size(118, 30);
            this.buttonUseSelected.TabIndex = 0;
            this.buttonUseSelected.Text = "Use this region";
            this.buttonUseSelected.UseVisualStyleBackColor = false;
            this.buttonUseSelected.Click += new System.EventHandler(this.buttonUseSelected_Click);
            // 
            // InstalledGamesForm
            // 
            this.AcceptButton = this.buttonUseSelected;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(680, 430);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(620, 360);
            this.Name = "InstalledGamesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EBOOT EXPRESS - Detected game regions";
            this.BackColor = System.Drawing.Color.FromArgb(12, 18, 29);
            this.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.mainLayout.BackColor = System.Drawing.Color.FromArgb(12, 18, 29);
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(12, 18, 29);
            this.gridInstalled.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.gridInstalled.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridInstalled.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(19, 29, 44);
            this.gridInstalled.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridInstalled.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 79, 94);
            this.gridInstalled.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gridInstalled.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.gridInstalled.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(17, 27, 41);
            this.gridInstalled.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridInstalled.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 79, 94);
            this.gridInstalled.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gridInstalled.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 47, 67);
            this.gridInstalled.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridInstalled.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(31, 47, 67);
            this.gridInstalled.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.gridInstalled.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridInstalled.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(26, 39, 57);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(229, 237, 247);
            this.buttonCancel.FlatAppearance.BorderSize = 1;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(46, 63, 84);
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 57, 78);
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(33, 48, 66);
            this.buttonUseSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUseSelected.BackColor = System.Drawing.Color.FromArgb(42, 211, 193);
            this.buttonUseSelected.ForeColor = System.Drawing.Color.FromArgb(7, 24, 33);
            this.buttonUseSelected.FlatAppearance.BorderSize = 1;
            this.buttonUseSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(42, 211, 193);
            this.buttonUseSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(68, 226, 207);
            this.buttonUseSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(27, 166, 153);
            this.buttonUseSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInstalled)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.DataGridView gridInstalled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGame;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitleId;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUseSelected;
    }
}
