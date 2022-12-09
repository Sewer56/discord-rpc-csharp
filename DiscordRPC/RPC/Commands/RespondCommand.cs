using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.RPC.Payload;
using DiscordRPC.Trimming;

namespace DiscordRPC.RPC.Commands
{
    internal class RespondCommand : ICommand, IJsonSerializable<RespondCommand>
	{
		/// <summary>
		/// The user ID that we are accepting / rejecting
		/// </summary>
		[JsonPropertyName("user_id")]
		public string UserID { get; set; }

		/// <summary>
		/// If true, the user will be allowed to connect.
		/// </summary>
		[JsonIgnore]
		public bool Accept { get; set; }

		public IPayload PreparePayload(long nonce)
		{
			var payload = ArgumentPayload.Create(this, nonce);
			payload.Command = Accept ? Command.SEND_ACTIVITY_JOIN_INVITE : Command.CLOSE_ACTIVITY_JOIN_REQUEST;
			return payload;
		}

		/// <inheritdoc/>
		public static JsonTypeInfo<RespondCommand> GetTypeInfo() => RespondCommandContext.Default.RespondCommand;
	}
    
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
    [JsonSerializable(typeof(RespondCommand))]
    internal partial class RespondCommandContext : JsonSerializerContext { }
}
