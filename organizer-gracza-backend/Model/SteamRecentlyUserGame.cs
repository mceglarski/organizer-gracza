using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamRecentlyUserGame
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("games")]
        public List<SteamRecentlyGame> Games { get; set; }
    }
}