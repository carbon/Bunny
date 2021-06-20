#nullable disable

using System;
using System.Text.Json.Serialization;

namespace BunnyCdn
{
    public sealed class Video
    {

        // {
        //   "captions":[],
        //   "hasMP4Fallback":false,
        //   "collectionId":"",
        //   "thumbnailFileName":"thumbnail.jpg"
        // }

        [JsonPropertyName("videoLibraryId")]
        public long VideoLibraryId { get; init; }

        [JsonPropertyName("guid")]
        public Guid Guid { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("dateUploaded")]
        public DateTime? DateUploaded { get; init; }

        [JsonPropertyName("views")]
        public long Views { get; init; }

        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; init; }

        [JsonPropertyName("length")]
        public int Length { get; init; }

        [JsonPropertyName("status")]
        public int Status { get; init; }

        [JsonPropertyName("framerate")]
        public double Framerate { get; init; }

        [JsonPropertyName("width")]
        public int Width { get; init; }

        [JsonPropertyName("height")]
        public int Height { get; init; }

        [JsonPropertyName("thumbnailCount")]
        public double ThumbnailCount { get; init; }

        [JsonPropertyName("encodeProgress")]
        public double EncodeProgress { get; init; }

        [JsonPropertyName("storageSize")]
        public long StorageSize { get; init; }

        [JsonPropertyName("availableResolutions")]
        public string AvailableResolutions { get; init; }

    }
}