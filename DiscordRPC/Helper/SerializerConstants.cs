using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordRPC.Helper
{
    internal static class SerializerConstants
    {
        public class JsonStringEnumConverterDefault : JsonStringEnumConverter
        {
            public JsonStringEnumConverterDefault() : base(JsonNamingPolicy.CamelCase, true) { }
        }
    }
}
