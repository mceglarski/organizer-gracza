using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAvailableGameStats
    {
        [JsonProperty("achievements")]
        public ICollection<SteamAchievementDetails> Achievements { get; set; }
    }
}