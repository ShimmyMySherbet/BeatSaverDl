using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaverDl.APIs.BeatSaver
{
    public class BeatSaverMap
    {
        public BeatSaverApiResponse response { get; set; }
        public bool Success { get; set; }
        public string Name { get; set; }
        public string HashToDownload { get; set; }
    }
}
