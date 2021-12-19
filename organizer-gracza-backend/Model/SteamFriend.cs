using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamFriend
    {
        [JsonProperty("steamid")]
        public string SteamId { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("friend_since")]
        public int FriendSince { get; set; }
    }
}