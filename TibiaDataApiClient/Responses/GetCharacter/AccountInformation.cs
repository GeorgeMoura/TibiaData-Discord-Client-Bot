using Newtonsoft.Json;
using TibiaDataApiClient.CommonData;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class AccountInformation
    {
        [JsonProperty("loyalty_title", NullValueHandling = NullValueHandling.Ignore)]
        public string loyalty_title { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateInfo created { get; set; }
    }
}
