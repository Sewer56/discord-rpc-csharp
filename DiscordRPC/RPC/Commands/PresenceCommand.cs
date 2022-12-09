using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.RPC.Payload;
using DiscordRPC.Trimming;

namespace DiscordRPC.RPC.Commands
{
	internal class PresenceCommand : ICommand, IJsonSerializable<PresenceCommand>
	{
		/// <summary>
		/// The process ID
		/// </summary>
		[JsonPropertyName("pid")]
		public int PID { get; set; }

		/// <summary>
		/// The rich presence to be set. Can be null.
		/// </summary>
		[JsonPropertyName("activity")]
		public RichPresence Presence { get; set; }

		public IPayload PreparePayload(long nonce)
		{
			var payload = ArgumentPayload.Create(this, nonce);
			payload.Command = Command.SET_ACTIVITY;
			return payload;
		}

		/// <inheritdoc/>
		public static JsonTypeInfo<PresenceCommand> GetTypeInfo() => PresenceCommandContext.Default.PresenceCommand;
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(PresenceCommand))]
	internal partial class PresenceCommandContext : JsonSerializerContext { }
}
