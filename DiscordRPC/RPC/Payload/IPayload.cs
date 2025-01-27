﻿using DiscordRPC.Converters;
using System.Text.Json.Serialization;

namespace DiscordRPC.RPC.Payload
{
    /// <summary>
    /// Base Payload that is received by both client and server
    /// </summary>
    internal abstract class IPayload
	{
		/// <summary>
		/// The type of payload
		/// </summary>
		[JsonPropertyName("cmd")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Command Command { get; set; }

		/// <summary>
		/// A incremental value to help identify payloads
		/// </summary>
		[JsonPropertyName("nonce")]
		public string Nonce { get; set; }

		protected IPayload() { }
        protected IPayload(long nonce)
		{
			Nonce = nonce.ToString();
		}

		public override string ToString()
		{
			return "Payload || Command: " + Command.ToString() + ", Nonce: " + (Nonce != null ? Nonce.ToString() : "NULL");
		}

		public abstract string Serialize();
	}
}

