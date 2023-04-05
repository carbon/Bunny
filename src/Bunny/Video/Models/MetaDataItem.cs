#nullable disable

using System.Text.Json.Serialization;

namespace Bunny.Cdn;

public sealed class MetaDataItem
{
    [JsonPropertyName("property")]
    public string Property { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}