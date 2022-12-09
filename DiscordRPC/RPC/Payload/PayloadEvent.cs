using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.Helper;
using DiscordRPC.Trimming;

namespace DiscordRPC.RPC.Payload
{
	/// <summary>
	/// Used for Discord IPC Events
	/// </summary>
	internal class EventPayload : IPayload, IJsonSerializable<EventPayload>
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
		public ServerEvent Event { get; set; } = ServerEvent.NULL;

		// Note: This is a hack to work around the lack of nullable support in source generated
		// 		 System.Text.Json. It's ugly, but if there's any positive, it also is more performant.
		[EditorBrowsable(EditorBrowsableState.Never)]
		[JsonPropertyName("evt")]
		public string _event
		{
			get => Enum.GetName(Event);
			set
			{
				Enum.TryParse(value, out ServerEvent evt);
				Event = evt;
			}
		}

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
		public T GetObject<T>() where T : IJsonSerializable<T>, new()
		{
			if (Data.ValueKind == JsonValueKind.Undefined) 
                return default(T);

			var json = Data.GetRawText();
            return JsonSerializer.Deserialize(json, T.GetTypeInfo());
        }

		public static JsonTypeInfo<EventPayload> GetTypeInfo() => EventPayloadContext.Default.EventPayload;

		/// <summary>
        /// Converts the object into a human readable string
        /// </summary>
        /// <returns></returns>
		public override string ToString()
		{
			return "Event " + base.ToString() + ", Event: " + Event;
		}

		public override string Serialize() => JsonSerializer.Serialize(this, EventPayloadContext.Default.EventPayload);
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(EventPayload))]
	internal partial class EventPayloadContext : JsonSerializerContext { }
}
