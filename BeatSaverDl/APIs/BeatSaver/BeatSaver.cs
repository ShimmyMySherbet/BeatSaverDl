using BeatSaverDl.APIs.Common;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeatSaverDl.APIs.BeatSaver
{
    public static class BeatSaver
    {
        private const string BeatSaverURLPrefix = "https://api.beatsaver.com";

        public static async Task<BeatSaberMap> GetBeatSaberMap(string id)
        {
            var map = await GetMap(id);
            if (map.Success)
            {
                var rmap = map.response.map;
                return new BeatSaberMap()
                {
                    Name = rmap.name,
                    Description = rmap.description,
                    Author = rmap.metadata.levelAuthorName,
                    DownloadURL = rmap.versions.LastOrDefault()?.downloadURL,
                    CoverURL = rmap.versions.LastOrDefault()?.coverURL,
                    Mapper = rmap.uploader.name,
                    BPM = rmap.metadata.bpm,
                    Ranked = rmap.ranked,
                    Rating = rmap.stats.score,
                    ID = id,
                    Difficulties = rmap.versions.LastOrDefault().diffs.Where(x => x.characteristic.Equals("standard", StringComparison.InvariantCultureIgnoreCase)).Select(x => x.difficulty).ToArray()
                };
            }
            else
            {
                return null;
            }
        }

        public static async Task<BeatSaverMap> GetMap(string id)
        {
            string urlSegment = "/maps/id/";

            BeatSaverMap map = new BeatSaverMap
            {
                Success = false
            };

            try
            {
                BeatSaverApiResponse beatsaver = await GetResponse(BeatSaverURLPrefix + urlSegment + id);
                if (beatsaver != null && beatsaver.map != null)
                {
                    map.response = beatsaver;

                    BeatSaverApiResponseMap.BeatsaverMapVersion mapVersion = null;
                    foreach (var version in map.response.map.versions)
                    {
                        if (mapVersion == null || version.createdAt > mapVersion.createdAt) mapVersion = version;
                    }
                    map.HashToDownload = mapVersion.hash;
                    map.Success = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return map;
        }

        private static async Task<BeatSaverApiResponse> GetResponse(string url)
        {
            BeatSaverApiResponse response = new BeatSaverApiResponse();
            try
            {
                var HttpClient = new HttpClient();
                var resp = await HttpClient.GetAsync(url);
                response.statusCode = resp.StatusCode;
                string body = await resp.Content.ReadAsStringAsync();

                if (response.statusCode == HttpStatusCode.OK)
                {
                    response.map = JsonSerializer.Deserialize<BeatSaverApiResponseMap>(body);
                    return response;
                }
                else
                {
                    return response;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}