using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamUserFriendsResponse
    {
        [JsonProperty("friendslist")]
        public SteamFriendsList FriendsList { get; set; }
    }
}