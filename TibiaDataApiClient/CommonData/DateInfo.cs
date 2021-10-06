

using Newtonsoft.Json;

namespace TibiaDataApiClient.CommonData
{
    public class DateInfo
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("timezone_type")]
        public int timezone_type { get; set; }
        [JsonProperty("timezone")]
        public string timezone { get; set; }
    }
}
