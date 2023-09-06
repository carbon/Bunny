using System.Text.Json.Serialization;

namespace Bunny.Streaming;

[method: JsonConstructor]
public readonly struct MetaDataItem(string property, string value)
{
    [JsonPropertyName("property")]
    public string Property { get; } = property;

    [JsonPropertyName("value")]
    public string Value { get; } = value;
}