
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace EbootExpress
{
    public partial class PackageImportForm : Form
    {
        private readonly BindingList<PackageAsset> assets;

        internal PackageImportForm(PackageImportData package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            InitializeComponent();
            WinFormsTheme.EnableDarkTitleBar(this);
            assets = new BindingList<PackageAsset>(package.Assets.ToList());
            labelPackageTitle.Text = package.PackageName;
            labelPackagePath.Text = package.PackageDirectory;
            labelInstructionsSummary.Text = string.Format(
                System.Globalization.CultureInfo.CurrentCulture,
                "{0} file(s) found; {1} read/instruction document(s) parsed. Check the suggested PS3 folders before staging.",
                assets.Count, package.Documents.Count);
            memoInstructions.Text = package.InstructionsText;
            gridPackage.DataSource = assets;
            UncheckConflictingEbootVariants();
        }

        internal IList<PackageAsset> SelectedAssets
        {
            get
            {
                gridPackage.EndEdit();
                return assets.Where(asset => asset.Include).ToList();
            }
        }

        private void buttonAddSelected_Click(object sender, EventArgs e)
        {
            if (!SelectedAssets.Any())
            {
                MessageBox.Show(this, "Select at least one package file to stage.",
                    "No files selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void gridPackage_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colRemoteFileName.Index)
            {
                PackageAsset asset = gridPackage.Rows[e.RowIndex].DataBoundItem as PackageAsset;
                if (asset != null && asset.IsEboot)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridPackage_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridPackage.IsCurrentCellDirty)
            {
                gridPackage.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UncheckConflictingEbootVariants()
        {
            var conflicts = assets
                .Where(asset => asset.IsEboot)
                .GroupBy(asset => (asset.RemoteDirectory ?? string.Empty).TrimEnd('/')
                    + "/" + asset.RemoteFileName, StringComparer.OrdinalIgnoreCase)
                .Where(group => group.Count() > 1);

            foreach (var conflict in conflicts)
            {
                foreach (PackageAsset asset in conflict)
                {
                    asset.Include = false;
                }
            }
        }
    }
}
