using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaverDl.Models
{
    public delegate void MapDownloadProgress(MapDownloadTask task, float progress);
    public delegate void MapDownloadComplete(MapDownloadTask task);
}
