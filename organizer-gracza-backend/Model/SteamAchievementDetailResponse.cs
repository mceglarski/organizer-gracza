using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAchievementDetailResponse
    {
        [JsonProperty("game")]
        public SteamAchievementGame Game { get; set; }
    }
}