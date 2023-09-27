using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class CreateVideoCollection(long libraryId, string name)
{
    [JsonIgnore]
    public long LibraryId { get; } = libraryId;

    [JsonPropertyName("name")]
    public string Name { get; } = name;
}