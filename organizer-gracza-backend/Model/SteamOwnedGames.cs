using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamOwnedGames
    {
        [JsonProperty("appid")]
        public int AppId { get; set; }

        [JsonProperty("playtime_forever")]
        public int PlayTimeForever { get; set; }
    }
}