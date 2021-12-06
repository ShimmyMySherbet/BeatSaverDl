using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using BeatSaverDl.APIs.Common;
using BeatSaverDl.Models;

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
            ContextMenuStrip = cmxControl;
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
            downloadTask.DownloadFailed += DownloadTask_DownloadFailed;
            progDownload.Maximum = 100;
        }

        private void DownloadTask_DownloadFailed(MapDownloadTask task)
        {
            Invoke(new Action(() =>
            {
                if (Program.NotifyDownload)
                {
                    Program.Icon.SendDownloadFailed(Map, DownloadTask.Retries);
                }
            }));
        }

        private void DownloadTask_DownloadComplete(MapDownloadTask task)
        {
            Debug.WriteLine($"prog: Complete");

            Invoke(new Action(() =>
            {
                progDownload.Visible = false;
                if (Program.NotifyDownload)
                {
                    Program.Icon.SendDownloadFinished(Map);
                }
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