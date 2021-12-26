using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamUserAchievement
    {
        [JsonProperty("apiname")]
        public string Apiname { get; set; }

        [JsonProperty("achieved")]
        public int Achieved { get; set; }

        [JsonProperty("unlocktime")]
        public int Unlocktime { get; set; }
    }
}