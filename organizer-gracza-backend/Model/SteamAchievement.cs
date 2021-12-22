using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAchievement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }
    }
}