using Newtonsoft.Json;


namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class Achievements
    {
        [JsonProperty("stars", NullValueHandling = NullValueHandling.Ignore)]
        public int stars { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
    }
}
