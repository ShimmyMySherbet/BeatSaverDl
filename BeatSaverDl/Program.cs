using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using BeatSaverDl.Models;
using BeatSaverDl.UI;

namespace BeatSaverDl
{
    internal static class Program
    {
        public const string Protocal = "beatsaver";
        public const string AppName = "Beat Saver Downloader";
        public const string ProtocalFormat = "%1";
        public static DownloadMenu DownloadMenu;
        public static string[] InstanceArgs;
        public static List<string> QueueDownloadMaps = new List<string>();
        public static INIFile Settings;

        public static bool AutoFocus = false;
        public static bool NotifyDownload = false;
        public static string BeatSaberPath;

        public static IconManager Icon;

        [STAThread]
        private static void Main(string[] args)
        {
            InstanceArgs = args;
            if (args.Length > 0 && args[0] == "-install")
            {
                if (IsAdministrator())
                {
                    var path = Process.GetCurrentProcess().MainModule.FileName;
                    RegistryManager.Register(Protocal, AppName, path, ProtocalFormat);
                    MessageBox.Show("Protocal Handler Installed.");
                }
                else
                {
                    MessageBox.Show("Cannot install protocal handler: App is not running as administrator.");
                }
                return;
            }
            var basePath = AppContext.BaseDirectory;
            var settingsFile = Path.Combine(basePath, "settings.ini");
            bool newInstall = false;
            if (!File.Exists(settingsFile))
            {
                newInstall = true;
            }
            Icon = new IconManager();

            Settings = new INIFile(settingsFile);

            Settings.Enforce("AutoFocus", "false");
            Settings.Enforce("BeatSaberPath", @"C:\Program Files (x86)\Steam\steamapps\common\Beat Saber");
            Settings.Enforce("NotifyDownloaded", "false");
            Settings.Save(settingsFile);
            RefreshSettings();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(BeatSaberPath))
            {
                if (MessageBox.Show("Failed to find your Beat Saber install folder. Please set the beat saber path in settings.", "Beat Saber path missing", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    using (var settings = new SettingsWindow())
                    {
                        if (settings.ShowDialog() == DialogResult.Cancel)
                        {
                            MessageBox.Show("Note: This app annot work without your Beat Saber install path.");
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            if (newInstall)
            {
                if (MessageBox.Show("Would you like to install the BeatSaver protocal handler?\nThis will allow you to use this app to handle one-click map installs on BeatSaver.com", "First Run", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    AskInstallHandler();
                }
            }

            DownloadMenu = new DownloadMenu();
            var controller = new SingleInstanceController(DownloadMenu);
            controller.Run(args);
        }

        public static void AskInstallHandler()
        {
            var path = Process.GetCurrentProcess().MainModule.FileName;
            var proc = new ProcessStartInfo()
            {
                FileName = path,
                Arguments = "-install",
                Verb = "runas",
                UseShellExecute = true
            };
            var pr = Process.Start(proc);
            pr.WaitForExit();
        }

        public static void RefreshSettings()
        {
            AutoFocus = bool.Parse(Settings["AutoFocus"]);
            NotifyDownload = bool.Parse(Settings["NotifyDownloaded"]);
            BeatSaberPath = Settings["BeatSaberPath"];
            Icon.SendUpdateEnabled(NotifyDownload);
        }

        public static void NotifySelf()
        {
            NotifyNewInstance(InstanceArgs);
        }

        public static void NotifyNewInstance(string[] args)
        {
            if (args.Length >= 1)
            {
                var arg = args[0];
                var protKey = $"{Protocal}:";

                if (arg.StartsWith(protKey))
                {
                    arg = arg.Remove(0, protKey.Length);
                }
                arg = arg.Trim('/', '\\');

                ThreadPool.QueueUserWorkItem(async (_) => await DownloadMenu.StartNewDownload(arg));
                return;
            }
            Debug.WriteLine($"Unknown Command: {string.Join(" ", args)}");
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}