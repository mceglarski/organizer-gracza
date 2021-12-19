using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAchievementGame
    {
        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("availableGameStats")]
        public SteamAvailableGameStats AvailableGameStats { get; set; }
    }
}