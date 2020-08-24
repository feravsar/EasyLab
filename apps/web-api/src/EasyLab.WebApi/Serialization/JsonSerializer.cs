using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace EasyLab.WebApi.Serialization
{

    public sealed class JsonSerializer
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {

            ContractResolver = new JsonContractResolver(),
            NullValueHandling = NullValueHandling.Ignore

        };

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, _settings);
        }

        public sealed class JsonContractResolver : CamelCasePropertyNamesContractResolver
        {

        }

    }

}
