using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAchievementResponse
    {
        [JsonProperty("achievementpercentages")]
        public SteamAchievementPercentages AchievementPercentages { get; set; }
    }
}