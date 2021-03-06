using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamAchievementDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("defaultvalue")]
        public int Defaultvalue { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("hidden")]
        public int Hidden { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icongray")]
        public string IconGray { get; set; }
    }
}