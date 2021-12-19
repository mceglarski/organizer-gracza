using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamPlayerResponse
    {
        [JsonProperty("players")]
        public ICollection<SteamPlayer> Players { get; set; }
    }
}