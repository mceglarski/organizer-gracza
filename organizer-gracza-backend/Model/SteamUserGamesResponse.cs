using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamUserGamesResponse
    {
        [JsonProperty("response")]
        public SteamGames Response { get; set; }
    }
}