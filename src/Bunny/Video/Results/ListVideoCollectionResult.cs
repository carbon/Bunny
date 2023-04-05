#nullable disable

using System.Text.Json.Serialization;

namespace Bunny.Cdn;

public sealed class ListVideoCollectionResult
{
    [JsonPropertyName("totalItems")]
    public long TotalItems { get; init; }

    [JsonPropertyName("currentPage")]
    public long CurrentPage { get; init; }

    [JsonPropertyName("itemsPerPage")]
    public long ItemsPerPage { get; init; }

    [JsonPropertyName("items")]
    public VideoCollection[] Items { get; init; }
}