using Newtonsoft.Json;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class Guild
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty("rank", NullValueHandling = NullValueHandling.Ignore)]
        public string rank { get; set; }
    }
}
