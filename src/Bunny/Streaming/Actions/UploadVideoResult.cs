#nullable disable

using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class UploadVideoResult
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }
}
