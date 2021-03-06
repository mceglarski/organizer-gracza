using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamNewsItem
    {
        [JsonProperty("gid")]
        public string GId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("is_external_url")]
        public bool IsExternalUrl { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("contents")]
        public string Contents { get; set; }

        [JsonProperty("feedlabel")]
        public string FeedLabel { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("feedname")]
        public string FeedName { get; set; }

        [JsonProperty("feed_type")]
        public int FeedType { get; set; }

        [JsonProperty("appid")]
        public int AppId { get; set; }
    }
}