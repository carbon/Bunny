﻿#nullable disable

using System.Text.Json.Serialization;

namespace Bunny.Streaming;

public sealed class FetchVideoResult
{
    [JsonPropertyName("success")]
    public bool Success { get; init; }

    [JsonPropertyName("message")]
    public string Message { get; init; }

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; init; }
}