using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordRPC.Helper
{
    internal static class SerializerConstants
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            IgnoreNullValues = true,
            WriteIndented = false,
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
    }
}
