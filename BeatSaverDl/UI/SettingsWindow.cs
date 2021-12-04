using System;
using System.IO;
using System.Windows.Forms;

namespace BeatSaverDl.UI
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            cbAutoFocus.Checked = Program.AutoFocus;
            cbNotifyDownloaded.Checked = Program.NotifyDownload;
            txtPath.Text = Program.BeatSaberPath;
        }

        private void OnSave(object sender, EventArgs e)
        {
            txtPath.Text = txtPath.Text.Replace("\"", "");
            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show(this, "Folder does not exist", "The specified folder for Beat Saber Path does not exist.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.Settings["AutoFocus"] = cbAutoFocus.Checked.ToString();
            Program.Settings["NotifyDownloaded"] = cbNotifyDownloaded.Checked.ToString();
            Program.Settings["BeatSaberPath"] = txtPath.Text;
            Program.Settings.Save();
            Program.RefreshSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BrowseForFolder(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog() { Description = "Select Beat Saber Install", UseDescriptionForTitle = true })
            {
                ofd.ShowNewFolderButton = false;

                if (Directory.Exists(Program.BeatSaberPath))
                {
                    ofd.SelectedPath = Program.BeatSaberPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = ofd.SelectedPath;
                }
            }
        }

        private void OnInstallRequested(object sender, EventArgs e)
        {
            Program.AskInstallHandler();
        }
    }
}