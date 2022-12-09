using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.Trimming;

namespace DiscordRPC.RPC.Payload
{
	internal class ClosePayload : IPayload, IJsonSerializable<ClosePayload>
	{
		/// <summary>
		/// The close code the discord gave us
		/// </summary>
		[JsonPropertyName("code")]
		public int Code { get; set; }

		/// <summary>
		/// The close reason discord gave us
		/// </summary>
		[JsonPropertyName("message")]
		public string Reason { get; set; }

		public static JsonTypeInfo<ClosePayload> GetTypeInfo() => ClosePayloadContext.Default.ClosePayload;
		
		public override string Serialize() => JsonSerializer.Serialize(this, ClosePayloadContext.Default.ClosePayload);
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(ClosePayload))]
	internal partial class ClosePayloadContext : JsonSerializerContext { }
}
