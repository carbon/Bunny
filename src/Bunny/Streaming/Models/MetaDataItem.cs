using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public readonly struct MetaDataItem
{
    [JsonConstructor]
    public MetaDataItem(string property, string value)
    {
        Property = property;
        Value = value;
    }

    [JsonPropertyName("property")]
    public string Property { get; }

    [JsonPropertyName("value")]
    public string Value { get; }
}