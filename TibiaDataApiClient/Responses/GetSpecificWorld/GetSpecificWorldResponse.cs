using Newtonsoft.Json;
using TibiaDataApiClient.CommonData;

namespace TibiaDataApiClient.Responses.GetSpecificWorld
{
    public class GetSpecificWorldResponse
    {
        [JsonProperty("world", NullValueHandling = NullValueHandling.Ignore)]
        public World world { get; set; }

        [JsonProperty("information", NullValueHandling = NullValueHandling.Ignore)]
        public ApiMetadata information { get; set; }
    }
}
