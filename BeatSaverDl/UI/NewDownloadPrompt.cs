using System;
using System.Linq;
using System.Windows.Forms;

namespace BeatSaverDl.UI
{
    public partial class NewDownloadPrompt : Form
    {
        public string MapID;

        public NewDownloadPrompt()
        {
            InitializeComponent();
        }

        private void txtMapID_TextChanged(object sender, EventArgs e)
        {
            MapID = txtMapID.Text.Split('/').Last();
        }

        private void txtDownload_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}