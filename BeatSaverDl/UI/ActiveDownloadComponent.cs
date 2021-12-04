using BeatSaverDl.APIs.Common;
using BeatSaverDl.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BeatSaverDl.UI
{
    public partial class ActiveDownloadComponent : UserControl
    {
        public string MapName { get; }
        public MapDownloadTask DownloadTask { get; }
        public BeatSaberMap Map { get; }

        public ActiveDownloadComponent()
        {
            InitializeComponent();
        }

        public ActiveDownloadComponent(Image icon, MapDownloadTask downloadTask)
        {
            Map = downloadTask.Map;
            InitializeComponent();
            lblMap.Text = downloadTask.Map.Name;
            pbArtwork.Image = icon;
            MapName = downloadTask.Map.Name;
            DownloadTask = downloadTask;
            lblAuthor.Text = $"Mapper: {Map.Mapper}";
            lblRanked.Text = Map.Ranked ? "Ranked" : "Unranked";
            lblDif.Text = string.Join(" ", Map.Difficulties);
            downloadTask.DownloadProgress += DownloadTask_DownloadProgressUpdated;
            DownloadTask.DownloadComplete += DownloadTask_DownloadComplete;
            progDownload.Maximum = 100;
        }

        private void DownloadTask_DownloadComplete(MapDownloadTask task)
        {
            Debug.WriteLine($"prog: Complete");

            Invoke(new Action(() =>
            {
                progDownload.Visible = false;
            }));
        }

        private void DownloadTask_DownloadProgressUpdated(MapDownloadTask task, float progress)
        {
            Invoke(new Action(() => progDownload.Value = (int)progress));
        }

        private void ActiveDownloadComponent_Load(object sender, EventArgs e)
        {
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.DownloadMenu.AskRemove(this);
        }
    }
}