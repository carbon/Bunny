#nullable disable

using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class ListVideosResult
{
    [JsonPropertyName("totalItems")]
    public long TotalItems { get; init; }

    [JsonPropertyName("currentPage")]
    public long CurrentPage { get; init; }

    [JsonPropertyName("itemsPerPage")]
    public long ItemsPerPage { get; init; }

    [JsonPropertyName("items")]
    public Video[] Items { get; init; }
}