using Newtonsoft.Json;
using System.Collections.Generic;
using TibiaDataApiClient.CommonData;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class Characters
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        [JsonProperty("achievements", NullValueHandling = NullValueHandling.Ignore)]
        public List<Achievements> achievements { get; set; }

        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public List<Deaths> deaths { get; set; }

        [JsonProperty("account_information", NullValueHandling = NullValueHandling.Ignore)]
        public AccountInformation account_information { get; set; }

        [JsonProperty("other_characters", NullValueHandling = NullValueHandling.Ignore)]
        public List<OtherCharacters> other_characters { get; set; }
        
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string error { get; set; }
    }
}
