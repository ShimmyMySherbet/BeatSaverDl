using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using BeatSaverDl.APIs.Common;

namespace BeatSaverDl.Models
{
    public class MapDownloadTask
    {
        public BeatSaberMap Map { get; }

        private MarshalAllocMemoryStream DownloadBuffer;

        public event MapDownloadProgress DownloadProgress;

        public event MapDownloadComplete DownloadComplete;

        private int BufferSize = 1024;

        public int DownloadSize { get; private set; }
        public int Downloaded { get; private set; }

        private DateTime? LastNotify = null;

        public MapDownloadTask(BeatSaberMap map)
        {
            Map = map;
        }

        public void StartDownload()
        {
            DownloadBuffer?.Dispose();
            Task.Run(Download);
        }

        private async Task Download()
        {
            var request = WebRequest.CreateHttp(Map.DownloadURL);
            request.Method = "GET";
            using (var response = await request.GetResponseAsync())
            using (var network = response.GetResponseStream())
            {
                DownloadBuffer = new MarshalAllocMemoryStream((int)response.ContentLength);

                var buffer = new byte[BufferSize];
                Downloaded = 0;
                DownloadSize = (int)response.ContentLength;
                while (DownloadSize - Downloaded > 0)
                {
                    var rem = DownloadSize - Downloaded;
                    var blockSize = rem > BufferSize ? BufferSize : rem;

                    var read = await network.ReadAsync(buffer, 0, blockSize);
                    Downloaded += read;
                    if (read == 0)
                    {
                        break;
                    }
                    await DownloadBuffer.WriteAsync(buffer, 0, read);
                    NotifyBlockDownload();
                }
            }

            var outDirName = Path.Combine(Program.BeatSaberPath, "Beat Saber_Data", "CustomLevels", $"{Map.ID} ({Map.Name} - {Map.Author})");

            if (Directory.Exists(outDirName))
            {
                Directory.Delete(outDirName, true);
            }
            Directory.CreateDirectory(outDirName);

            DownloadBuffer.Position = 0;
            using (var zip = new ZipArchive(DownloadBuffer))
            {
                zip.ExtractToDirectory(outDirName);
            }

            DownloadComplete?.Invoke(this);
            DownloadBuffer.Dispose();
            DownloadBuffer = null;
        }

        private void NotifyBlockDownload()
        {
            if (LastNotify == null || DateTime.Now.Subtract(LastNotify.Value).TotalSeconds >= 0.3)
            {
                LastNotify = DateTime.Now;
                DownloadProgress?.Invoke(this, (Downloaded / (float)DownloadSize) * 100f);
            }
        }
    }
}