using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using DiscordRPC.Trimming;

namespace DiscordRPC.IO
{
	internal class Handshake : IJsonSerializable<Handshake>
	{       
		/// <summary>
		/// Version of the IPC API we are using
		/// </summary>
		[JsonPropertyName("v")]
		public int Version { get; set; }

		/// <summary>
		/// The ID of the app.
		/// </summary>
		[JsonPropertyName("client_id")]
		public string ClientID { get; set; }

		public static JsonTypeInfo<Handshake> GetTypeInfo() => HandshakeContext.Default.Handshake;
	}
	
	[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = false)]
	[JsonSerializable(typeof(Handshake))]
	internal partial class HandshakeContext : JsonSerializerContext { }
}
