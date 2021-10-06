using Newtonsoft.Json;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class Involved
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
    }
}
