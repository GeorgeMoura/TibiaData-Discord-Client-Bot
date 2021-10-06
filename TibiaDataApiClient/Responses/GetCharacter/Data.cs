using Newtonsoft.Json;
using System.Collections.Generic;
using TibiaDataApiClient.CommonData;

namespace TibiaDataApiClient.Responses.GetCharacter
{
    public class Data
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
        [JsonProperty("sex", NullValueHandling = NullValueHandling.Ignore)]
        public string sex { get; set; }
        [JsonProperty("vocation", NullValueHandling = NullValueHandling.Ignore)]
        public string vocation { get; set; }
        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public int level { get; set; }
        [JsonProperty("achievement_points", NullValueHandling = NullValueHandling.Ignore)]
        public long achievement_points { get; set; }
        [JsonProperty("world", NullValueHandling = NullValueHandling.Ignore)]
        public string world { get; set; }
        [JsonProperty("residence", NullValueHandling = NullValueHandling.Ignore)]
        public string residence { get; set; }
        [JsonProperty("married_to", NullValueHandling = NullValueHandling.Ignore)]
        public string married_to { get; set; }
        [JsonProperty("houses", NullValueHandling = NullValueHandling.Ignore)]
        public List<Houses> houses { get; set; }
        [JsonProperty("guild", NullValueHandling = NullValueHandling.Ignore)]
        public Guild guild { get; set; }
        [JsonProperty("last_login", NullValueHandling = NullValueHandling.Ignore)]
        public List<DateInfo> last_login { get; set; }
        [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
        public string comment { get; set; }
        [JsonProperty("account_status", NullValueHandling = NullValueHandling.Ignore)]
        public string account_status { get; set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }
    }
}
