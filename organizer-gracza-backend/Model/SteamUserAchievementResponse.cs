using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamUserAchievementResponse
    {
        [JsonProperty("playerstats")]
        public SteamPlayerStats playerstats { get; set; }
    }
}