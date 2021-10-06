using Newtonsoft.Json;
using TibiaDataApiClient.CommonData;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class GetCharacterResponse
    {
        [JsonProperty("characters", NullValueHandling = NullValueHandling.Ignore)]
        public Characters characters { get; set; }

        [JsonProperty("information", NullValueHandling = NullValueHandling.Ignore)]
        public ApiMetadata information { get; set; }
    }
}
