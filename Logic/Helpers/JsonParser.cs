using Newtonsoft.Json;

namespace Parser.Logic.Helpers
{
    public static class JsonParser
    {
        public static string Encode<T>(T p)
        {
            return JsonConvert.SerializeObject(p);
        }

        public static T Decode<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
