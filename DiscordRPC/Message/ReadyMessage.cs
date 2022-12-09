using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.Trimming;

namespace DiscordRPC.Message
{
	/// <summary>
	/// Called when the ipc is ready to send arguments.
	/// </summary>
	public class ReadyMessage : IMessage, IJsonSerializable<ReadyMessage>
	{
		/// <summary>
		/// The type of message received from discord
		/// </summary>
		public override MessageType Type { get { return MessageType.Ready; } }
		
		/// <summary>
		/// The configuration of the connection
		/// </summary>
		[JsonPropertyName("config")]
		public Configuration Configuration { get; set; }

		/// <summary>
		/// User the connection belongs too
		/// </summary>
		[JsonPropertyName("user")]
		public User User { get; set; }

		/// <summary>
		/// The version of the RPC
		/// </summary>
		[JsonPropertyName("v")]
		public int Version { get; set; }

		/// <inheritdoc/>
		public static JsonTypeInfo<ReadyMessage> GetTypeInfo() => ReadyMessageContext.Default.ReadyMessage;
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(ReadyMessage))]
	internal partial class ReadyMessageContext : JsonSerializerContext { }
}
