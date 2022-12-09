using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.Trimming;

namespace DiscordRPC.Message
{
	/// <summary>
	/// Called when the Discord Client wishes for this process to join a game. D -> C.
	/// </summary>
	public class JoinMessage : IMessage, IJsonSerializable<JoinMessage>
	{
		/// <summary>
		/// The type of message received from discord
		/// </summary>
		public override MessageType Type { get { return MessageType.Join; } }

		/// <summary>
		/// The <see cref="Secrets.JoinSecret" /> to connect with. 
		/// </summary>
		[JsonPropertyName("secret")]
		public string Secret { get; internal set; }

		/// <inheritdoc/>
		public static JsonTypeInfo<JoinMessage> GetTypeInfo() => JoinMessageContext.Default.JoinMessage;
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(JoinMessage))]
	internal partial class JoinMessageContext : JsonSerializerContext { }
}
