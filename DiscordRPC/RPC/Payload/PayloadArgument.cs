using DiscordRPC.Converters;
using DiscordRPC.Helper;
using System.Text.Json;
using System.Text.Json.Serialization;
using DiscordRPC.Trimming;

namespace DiscordRPC.RPC.Payload
{
	/// <summary>
	/// The payload that is sent by the client to discord for events such as setting the rich presence.
	/// <para>
	/// SetPrecense
	/// </para>
	/// </summary>
	internal class ArgumentPayload : IPayload
	{
		/// <summary>
		/// The data the server sent too us
		/// </summary>
		[JsonPropertyName("args")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public JsonElement Arguments { get; set; }
		
		public ArgumentPayload() { Arguments = default; }

		public static ArgumentPayload Create<T>(T args, long nonce) where T : IJsonSerializable<T>, new()
		{
			var payload = new ArgumentPayload();
			payload.Nonce = nonce.ToString();
			payload.SetObject<T>(args);
			return payload;
		}

		/// <summary>
		/// Sets the obejct stored within the data.
		/// </summary>
		/// <param name="obj"></param>
		public void SetObject<T>(T obj) where T : IJsonSerializable<T>, new()
		{
            var bytes = JsonSerializer.SerializeToUtf8Bytes(obj, T.GetTypeInfo());
            Arguments = JsonDocument.Parse(bytes).RootElement;
        }

		public override string ToString()
		{
			return "Argument " + base.ToString();
		}

		public override string Serialize() => JsonSerializer.Serialize(this, ArgumentPayloadContext.Default.ArgumentPayload);
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(ArgumentPayload))]
	internal partial class ArgumentPayloadContext : JsonSerializerContext { }
}

