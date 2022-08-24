#nullable disable

using System.Text.Json.Serialization;

namespace BunnyCdn;

public sealed class Video
{
    [JsonPropertyName("videoLibraryId")]
    public long VideoLibraryId { get; init; }

    [JsonPropertyName("collectionId")]
    public string CollectionId { get; init; }

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

    [JsonPropertyName("hasMP4Fallback")]
    public bool HasMp4Fallback { get; init; }

    [JsonPropertyName("storageSize")]
    public long StorageSize { get; init; }

    [JsonPropertyName("availableResolutions")]
    public string AvailableResolutions { get; init; }

    [JsonPropertyName("thumbnailFileName")]
    public string ThumbnailFileName { get; init; }

    [JsonPropertyName("metaTags")]
    public MetaDataItem[] MetaTags { get; set; }

    [JsonPropertyName("category")]
    public String Category { get; init; }

    // TODO: 
    //  "captions":[],
}