using DiscordRPC.Converters;
using DiscordRPC.Helper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordRPC.RPC.Payload
{
	/// <summary>
	/// Used for Discord IPC Events
	/// </summary>
	internal class EventPayload : IPayload
	{
		/// <summary>
		/// The data the server sent too us
		/// </summary>
		[JsonPropertyName("data")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public JsonElement Data { get; set; }

		/// <summary>
		/// The type of event the server sent
		/// </summary>
		[JsonPropertyName("evt")]
		public ServerEvent? Event { get; set; }

        /// <summary>
        /// Creates a payload with empty data
        /// </summary>
		public EventPayload() : base() { Data = default; }

        /// <summary>
        /// Creates a payload with empty data and a set nonce
        /// </summary>
        /// <param name="nonce"></param>
		public EventPayload(long nonce) : base(nonce) { Data = default; }
        
		/// <summary>
		/// Gets the object stored within the Data
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetObject<T>()
		{
			if (Data.ValueKind == JsonValueKind.Undefined) 
                return default(T);

			var json = Data.GetRawText();
            return JsonSerializer.Deserialize<T>(json, SerializerConstants.Options);
        }

        /// <summary>
        /// Converts the object into a human readable string
        /// </summary>
        /// <returns></returns>
		public override string ToString()
		{
			return "Event " + base.ToString() + ", Event: " + (Event.HasValue ? Event.ToString() : "N/A");
		}
	}
}
