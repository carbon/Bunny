using System;
using System.Text.Json.Serialization;

namespace BunnyCdn
{
    public sealed class FetchVideoRequest
    {
        public FetchVideoRequest(long libraryId, Guid videoId, string url)
        {
            LibraryId = libraryId;
            VideoId = videoId;
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        [JsonIgnore]
        public long LibraryId { get; }

        [JsonIgnore]
        public Guid VideoId { get; }

        [JsonPropertyName("url")]
        public string Url { get; }
    }
}