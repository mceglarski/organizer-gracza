using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAppNews
    {
        [JsonProperty("appid")]
        public int AppId { get; set; }

        [JsonProperty("newsitems")]
        public ICollection<SteamNewsItem> NewsItems { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}