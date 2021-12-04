using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaverDl.APIs.BeatSaver
{
    public class BeatSaverApiResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public BeatSaverRatelimit ratelimit { get; set; }
        public BeatSaverApiResponseMap map { get; set; }
    }
}
