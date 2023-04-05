using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class FetchVideoRequest
{
    public FetchVideoRequest(long libraryId, Guid videoId, string url)
    {
        ArgumentNullException.ThrowIfNull(url);

        LibraryId = libraryId;
        VideoId = videoId;
        Url = url;
    }

    [JsonIgnore]
    public long LibraryId { get; }

    [JsonIgnore]
    public Guid VideoId { get; }

    [JsonPropertyName("url")]
    public string Url { get; }
}
