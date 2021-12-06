using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaverDl.Models
{
    public delegate void MapDownloadProgressArgs(MapDownloadTask task, float progress);
    public delegate void MapDownloadUpdatedArgs(MapDownloadTask task);
    public delegate void MapDownloadUpdatedArgs<T>(MapDownloadTask task, T arg);
}
