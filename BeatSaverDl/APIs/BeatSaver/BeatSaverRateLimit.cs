using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaverDl.APIs.BeatSaver
{
    public class BeatSaverRatelimit
    {
        public int? Remaining { get; set; }
        public int? Total { get; set; }
        public int? Reset { get; set; }
        public DateTime ResetTime { get; set; }
        public async Task Wait()
        {
            await Task.Delay(new TimeSpan(Math.Max(ResetTime.Ticks - DateTime.UtcNow.Ticks, 0)));
        }
    }
}
