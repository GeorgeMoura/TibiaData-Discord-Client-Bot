using Newtonsoft.Json;

namespace TibiaDataApiClient.Responses.GetSpecificWorld
{
    public class Player
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public int level { get; set; }

        [JsonProperty("vocation", NullValueHandling = NullValueHandling.Ignore)]
        public string vocation { get; set; }
    }
}
