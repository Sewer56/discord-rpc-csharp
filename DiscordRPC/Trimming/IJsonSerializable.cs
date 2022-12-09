using System.Text.Json.Serialization.Metadata;

namespace DiscordRPC.Trimming;

/// <summary>
/// Represents a JSON object that can be serialized. 
/// </summary>
public interface IJsonSerializable<TType> where TType : IJsonSerializable<TType>, new()
{
    /// <summary>
    /// Gets the Source Generation Json Serializer Type Info.
    /// </summary>
    public static abstract JsonTypeInfo<TType> GetTypeInfo();
}