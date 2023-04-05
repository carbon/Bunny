using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class CreateVideoRequest
{
    public CreateVideoRequest(long libraryId, string? collectionId, string title)
    {
        LibraryId = libraryId;
        CollectionId = collectionId;
        Title = title;
    }

    [JsonIgnore]
    public long LibraryId { get; }

    [JsonPropertyName("collectionId")]
    public string? CollectionId { get; }

    [JsonPropertyName("title")]
    public string Title { get; }
}