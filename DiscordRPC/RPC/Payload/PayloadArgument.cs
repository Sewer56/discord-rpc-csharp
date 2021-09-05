using DiscordRPC.Converters;
using DiscordRPC.Helper;
using System.Text.Json;
using System.Text.Json.Serialization;

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
		
		public ArgumentPayload() : base() { Arguments = default; }
		public ArgumentPayload(long nonce) : base(nonce) { Arguments = default; }
		public ArgumentPayload(object args, long nonce) : base(nonce)
		{
			SetObject(args);
		}

		/// <summary>
		/// Sets the obejct stored within the data.
		/// </summary>
		/// <param name="obj"></param>
		public void SetObject(object obj)
		{
            var bytes = JsonSerializer.SerializeToUtf8Bytes(obj, SerializerConstants.Options);
            Arguments = JsonDocument.Parse(bytes).RootElement;
        }

		/// <summary>
		/// Gets the object stored within the Data
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetObject<T>()
		{
            var json = Arguments.GetRawText();
            return JsonSerializer.Deserialize<T>(json, SerializerConstants.Options);
        }

		public override string ToString()
		{
			return "Argument " + base.ToString();
		}
	}
}

