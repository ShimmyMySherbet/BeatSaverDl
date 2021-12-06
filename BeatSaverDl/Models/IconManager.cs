using System;
using System.Drawing;
using System.Windows.Forms;
using BeatSaverDl.APIs.Common;

namespace BeatSaverDl.Models
{
    public class IconManager
    {
        private bool WindowEnabled = false;
        private bool IconEnabled = false;
        private NotifyIcon Icon;
        private Icon IconImage;

        private void Update()
        {
            var shouldHaveIcon = WindowEnabled && IconEnabled;

            if (Icon != null && !shouldHaveIcon)
            {
                Icon.Dispose();
                Icon = null;
            }
            else if (Icon == null && shouldHaveIcon)
            {
                Icon = CreateIcon();
                Icon.Visible = true;
                Icon.BalloonTipClicked += IconClicked;
                Icon.Click += IconClicked;
            }
        }

        private void IconClicked(object sender, EventArgs e)
        {
            Program.DownloadMenu.Select();
            Program.DownloadMenu.Activate();
            Program.DownloadMenu.BringToFront();
        }

        private NotifyIcon CreateIcon()
        {
            return new NotifyIcon()
            {
                Icon = IconImage,
                Text = "Beatg Saver Dl"
            };
        }

        public void SendWindowEnabled(Icon windowIcon)
        {
            IconImage = windowIcon;
            WindowEnabled = true;
            Update();
        }

        public void SendUpdateEnabled(bool enabled)
        {
            IconEnabled = enabled;
            Update();
        }

        public void SendDownloadFinished(BeatSaberMap map)
        {
            if (IconEnabled && Icon != null)
            {
                Icon.ShowBalloonTip(1000, "Download Finished", $"Finished downloading {map.Name}", ToolTipIcon.None);
            }
        }

        public void SendDownloadFailed(BeatSaberMap map, int retries)
        {
            if (IconEnabled && Icon != null)
            {
                Icon.ShowBalloonTip(1000, "Download Failed", $"Failed to download {map.Name} after {retries} retries", ToolTipIcon.None);
            }
        }
    }
}