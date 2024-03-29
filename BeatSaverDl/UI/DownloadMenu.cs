﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeatSaverDl.APIs.BeatSaver;
using BeatSaverDl.Models;
using BeatSaverDl.UI;

namespace BeatSaverDl
{
    public partial class DownloadMenu : Form
    {
        public WorkingWatcher Work;

        public bool DownloadListOverflowing => FlowItems.VerticalScroll.Visible;

        public int DownloadListWidthBuffer => DownloadListOverflowing ? 35 : 15;

        public DownloadMenu()
        {
            InitializeComponent();
            Work = new WorkingWatcher(onWorkStateUpdate);
            SizeChanged += sizeChanged;
            this.Layout += DownloadMenu_Layout;
            Load += DownloadMenu_Load;
        }

        private void DownloadMenu_Load(object sender, EventArgs e)
        {
        }

        private void DownloadMenu_Layout(object sender, LayoutEventArgs e)
        {
            UpdateSizeLayout();
        }

        private void sizeChanged(object sender, EventArgs e)
        {
            UpdateSizeLayout();
        }

        public void UpdateSizeLayout()
        {
            FlowItems.SuspendLayout();

            foreach (var ct in FlowItems.Controls.OfType<Control>())
            {
                ct.Width = FlowItems.Width - DownloadListWidthBuffer;
            }

            FlowItems.ResumeLayout();
        }

        public async Task StartNewDownload(string mapID)
        {
            using (var work = Work.Register())
            {
                Debug.WriteLine($"Starting New Download: {mapID}");

                var map = await BeatSaver.GetBeatSaberMap(mapID);
                var download = new MapDownloadTask(map);
                var icon = await DownloadImageAsync(map.CoverURL);
                Invoke(new Action(() =>
                      {
                          var ct = new ActiveDownloadComponent(icon, download);
                          ct.Width = FlowItems.Width - 15;
                          ct.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                          FlowItems.Controls.Add(ct);
                          UpdateSizeLayout();
                      }));

                download.StartDownload();
            }
        }

        private void OnWindowLoad(object sender, EventArgs e)
        {
            Program.Icon.SendWindowEnabled(Icon);
            ThreadPool.QueueUserWorkItem(async (_) =>
            {
                string[] maps;
                lock (Program.QueueDownloadMaps)
                {
                    maps = Program.QueueDownloadMaps.ToArray();
                    Program.QueueDownloadMaps.Clear();
                }

                foreach (var map in maps)
                {
                    await StartNewDownload(map);
                }
            });
        }

        public void AskRemove(ActiveDownloadComponent comp)
        {
            Invoke(new Action(() =>
            {
                if (FlowItems.Controls.Contains(comp))
                {
                    FlowItems.Controls.Remove(comp);
                }
            }));
        }

        private async Task<Image> DownloadImageAsync(string url)
        {
            var req = WebRequest.CreateHttp(url);
            req.Method = "GET";
            using (var resp = await req.GetResponseAsync())
            using (var network = resp.GetResponseStream())
            using (var ms = new MarshalAllocMemoryStream(resp.ContentLength))
            {
                await network.CopyToAsync(ms);
                await ms.FlushAsync();
                Debug.WriteLine($"Downloaded cover image, {ms.Length} byets");
                ms.Position = 0;
                return Image.FromStream(ms);
            }
        }

        private void onWorkStateUpdate(bool working)
        {
            Invoke(new Action(() =>
            {
                pbLoading.Visible = working;
            }));
        }

        private void AddNewDownload(object sender, EventArgs e)
        {
            using (var prompt = new NewDownloadPrompt())
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    Task.Run(async () => await StartNewDownload(prompt.MapID));
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var settings = new SettingsWindow())
            {
                settings.ShowDialog();
            }
        }
    }
}