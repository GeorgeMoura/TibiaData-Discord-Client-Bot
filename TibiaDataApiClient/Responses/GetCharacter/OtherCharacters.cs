using Newtonsoft.Json;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class OtherCharacters
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty("world", NullValueHandling = NullValueHandling.Ignore)]
        public string world { get; set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }
    }
}
