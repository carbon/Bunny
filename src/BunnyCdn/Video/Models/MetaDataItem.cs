#nullable disable

using System.Text.Json.Serialization;

namespace BunnyCdn;

public sealed class MetaDataItem
{
    [JsonPropertyName("property")]
    public string Property { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}