using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.IO;
using DiscordRPC.Trimming;

namespace DiscordRPC.Message
{
	/// <summary>
	/// Called when the Discord Client wishes for this process to spectate a game. D -> C. 
	/// </summary>
	public class SpectateMessage : JoinMessage, IJsonSerializable<SpectateMessage>
	{
		/// <summary>
		/// The type of message received from discord
		/// </summary>
		public override MessageType Type { get { return MessageType.Spectate; } }

		/// <inheritdoc/>
		public new static JsonTypeInfo<SpectateMessage> GetTypeInfo() => SpectateMessageContext.Default.SpectateMessage;
	}
	
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(SpectateMessage))]
	internal partial class SpectateMessageContext : JsonSerializerContext { }
}
