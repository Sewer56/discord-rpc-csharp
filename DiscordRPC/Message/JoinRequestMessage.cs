using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.Trimming;

namespace DiscordRPC.Message
{
	/// <summary>
	/// Called when some other person has requested access to this game. C -> D -> C.
	/// </summary>
	public class JoinRequestMessage : IMessage, IJsonSerializable<JoinRequestMessage>
	{
		/// <summary>
		/// The type of message received from discord
		/// </summary>
		public override MessageType Type { get { return MessageType.JoinRequest; } }

		/// <summary>
		/// The discord user that is requesting access.
		/// </summary>
		[JsonPropertyName("user")]
		public User User { get; set; }

		/// <inheritdoc/>
		public static JsonTypeInfo<JoinRequestMessage> GetTypeInfo() => JoinRequestMessageContext.Default.JoinRequestMessage;
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(JoinRequestMessage))]
	internal partial class JoinRequestMessageContext : JsonSerializerContext { }
}
