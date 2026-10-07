
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace EbootExpress
{
    public partial class InstalledGamesForm : Form
    {
        private readonly BindingList<GameRegionPreset> installedPresets;

        internal InstalledGamesForm(
            IList<GameRegionPreset> presets,
            GameRegionPreset preferredPreset)
        {
            if (presets == null)
            {
                throw new ArgumentNullException("presets");
            }
            if (presets.Count == 0)
            {
                throw new ArgumentException("At least one installed game region is required.", "presets");
            }

            InitializeComponent();
            WinFormsTheme.EnableDarkTitleBar(this);
            installedPresets = new BindingList<GameRegionPreset>(presets.ToList());
            labelSummary.Text = string.Format(
                System.Globalization.CultureInfo.CurrentCulture,
                "{0} supported game folder(s) found under /dev_hdd0/game/. Select the game and region to use.",
                installedPresets.Count);
            gridInstalled.DataSource = installedPresets;
            SelectInitialRow(preferredPreset);
        }

        internal GameRegionPreset SelectedPreset
        {
            get
            {
                gridInstalled.EndEdit();
                DataGridViewRow selectedRow = gridInstalled.SelectedRows.Count > 0
                    ? gridInstalled.SelectedRows[0]
                    : gridInstalled.CurrentRow;
                return selectedRow == null ? null : selectedRow.DataBoundItem as GameRegionPreset;
            }
        }

        private void buttonUseSelected_Click(object sender, EventArgs e)
        {
            if (SelectedPreset == null)
            {
                MessageBox.Show(this, "Select an installed game folder.",
                    "No game selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SelectInitialRow(GameRegionPreset preferredPreset)
        {
            int selectedRow = 0;
            if (preferredPreset != null)
            {
                int preferredRow = installedPresets.ToList().FindIndex(preset =>
                    string.Equals(preset.Game, preferredPreset.Game, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(preset.TitleId, preferredPreset.TitleId, StringComparison.OrdinalIgnoreCase));
                if (preferredRow >= 0)
                {
                    selectedRow = preferredRow;
                }
            }

            if (selectedRow >= 0 && selectedRow < gridInstalled.Rows.Count)
            {
                gridInstalled.CurrentCell = gridInstalled.Rows[selectedRow].Cells[0];
                gridInstalled.Rows[selectedRow].Selected = true;
            }
        }
    }
}
