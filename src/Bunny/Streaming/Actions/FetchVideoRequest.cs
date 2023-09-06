using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class FetchVideoRequest(long libraryId, Guid videoId, string url)
{
    [JsonIgnore]
    public long LibraryId { get; } = libraryId;

    [JsonIgnore]
    public Guid VideoId { get; } = videoId;

    [JsonPropertyName("url")]
    public string Url { get; } = url ?? throw new ArgumentNullException(nameof(url));
}
