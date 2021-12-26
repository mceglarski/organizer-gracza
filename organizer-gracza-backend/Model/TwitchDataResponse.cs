using System.Collections.Generic;
using Newtonsoft.Json;

namespace organizer_gracza_backend.Model
{
    public class TwitchDataResponse
    {
        [JsonProperty("data")]
        public List<TwitchData> Data { get; set; }

        [JsonProperty("pagination")]
        public TwitchPagination Pagination { get; set; }
    }
}