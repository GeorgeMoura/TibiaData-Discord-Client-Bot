using Newtonsoft.Json;

namespace TibiaDiscordBot.Common.Utils
{
    public class Serializer
    {

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T Deserialize<T>(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }
    }
}
