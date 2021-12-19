using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAchievementPercentages
    {
        [JsonProperty("achievements")]
        public ICollection<SteamAchievement> Achievements { get; set; }
    }
}