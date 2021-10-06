using Newtonsoft.Json;
using System.Collections.Generic;

namespace TibiaDataApiClient.Responses.GetSpecificWorld
{
    public class World
    {
        [JsonProperty("world_information", NullValueHandling = NullValueHandling.Ignore)]
        public WorldInformation world_information { get; set; }

        [JsonProperty("players_online", NullValueHandling = NullValueHandling.Ignore)]
        public List<Player> players_online { get; set; }
    }
}
