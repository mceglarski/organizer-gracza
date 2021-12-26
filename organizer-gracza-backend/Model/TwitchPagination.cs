using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class TwitchPagination
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }
}