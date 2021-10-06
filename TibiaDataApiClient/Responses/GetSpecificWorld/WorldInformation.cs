using Newtonsoft.Json;
using System.Collections.Generic;

namespace TibiaDataApiClient.Responses.GetSpecificWorld
{
    public class WorldInformation
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        [JsonProperty("players_online", NullValueHandling = NullValueHandling.Ignore)]
        public string players_online { get; set; }

        [JsonProperty("online_record", NullValueHandling = NullValueHandling.Ignore)]
        public OnlineRecord online_record { get; set; }

        [JsonProperty("creation_date", NullValueHandling = NullValueHandling.Ignore)]
        public string creation_date { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string location { get; set; }

        [JsonProperty("pvp_type", NullValueHandling = NullValueHandling.Ignore)]
        public string pvp_type { get; set; }

        [JsonProperty("world_quest_titles", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> world_quest_titles { get; set; }

        [JsonProperty("battleye_status", NullValueHandling = NullValueHandling.Ignore)]
        public string battleye_status { get; set; }
    }
}
