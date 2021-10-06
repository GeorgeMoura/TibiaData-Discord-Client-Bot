using Newtonsoft.Json;
using TibiaDataApiClient.CommonData;

namespace TibiaDataApiClient.Responses.GetSpecificWorld
{
    public class OnlineRecord
    {
        [JsonProperty("players", NullValueHandling = NullValueHandling.Ignore)]
        public int players { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateInfo date { get; set; }
    }
}
