using Newtonsoft.Json;
using System.Collections.Generic;
using TibiaDataApiClient.CommonData;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class Deaths
    {
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateInfo date { get; set; }
        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public int level { get; set; }
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string reason { get; set; }
        [JsonProperty("involved", NullValueHandling = NullValueHandling.Ignore)]
        public List<Involved> involved { get; set; }
    }
}
