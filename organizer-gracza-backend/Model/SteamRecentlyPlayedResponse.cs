using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamRecentlyPlayedResponse
    {
        [JsonProperty("response")]
        public SteamRecentlyUserGame Response { get; set; }
    }
}