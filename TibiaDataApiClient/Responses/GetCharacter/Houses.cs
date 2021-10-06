using Newtonsoft.Json;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class Houses
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty("town", NullValueHandling = NullValueHandling.Ignore)]
        public string town { get; set; }
        [JsonProperty("paid", NullValueHandling = NullValueHandling.Ignore)]
        public string paid { get; set; }
        [JsonProperty("world", NullValueHandling = NullValueHandling.Ignore)]
        public string world { get; set; }
        [JsonProperty("houseid", NullValueHandling = NullValueHandling.Ignore)]
        public long houseid { get; set; }
    }
}
