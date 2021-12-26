using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamRecentlyGame
    {
        [JsonProperty("appid")]
        public int Appid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playtime_2weeks")]
        public int Playtime2weeks { get; set; }

        [JsonProperty("playtime_forever")]
        public int PlaytimeForever { get; set; }

        [JsonProperty("img_icon_url")]
        public string ImgIconUrl { get; set; }

        [JsonProperty("img_logo_url")]
        public string ImgLogoUrl { get; set; }

        [JsonProperty("playtime_windows_forever")]
        public int PlaytimeWindowsForever { get; set; }

        [JsonProperty("playtime_mac_forever")]
        public int PlaytimeMacForever { get; set; }

        [JsonProperty("playtime_linux_forever")]
        public int PlaytimeLinuxForever { get; set; }
    }
}