using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamNewsResponse
    {
        [JsonProperty("appnews")]
        public SteamAppNews AppNews { get; set; }  
    }
}