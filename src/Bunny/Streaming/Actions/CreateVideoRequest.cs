using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class CreateVideoRequest(long libraryId, string? collectionId, string title)
{
    [JsonIgnore]
    public long LibraryId { get; } = libraryId;

    [JsonPropertyName("collectionId")]
    public string? CollectionId { get; } = collectionId;

    [JsonPropertyName("title")]
    public string Title { get; } = title;
}