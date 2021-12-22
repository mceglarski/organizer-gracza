using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class SteamFriendsList
    {
        [JsonProperty("friends")]
        public ICollection<SteamFriend> Friends { get; set; }
    }
}