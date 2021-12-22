using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamUserResponse
    {
        [JsonProperty("response")]
        public SteamPlayerResponse Response { get; set; }
    }
}