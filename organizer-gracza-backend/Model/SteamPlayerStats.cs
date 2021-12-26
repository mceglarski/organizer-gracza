using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamPlayerStats
    {
        [JsonProperty("steamID")]
        public string SteamID { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("achievements")]
        public List<SteamUserAchievement> Achievements { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}