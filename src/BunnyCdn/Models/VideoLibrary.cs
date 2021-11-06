#nullable disable

using System;

namespace BunnyCdn;

public sealed class VideoLibrary
{
    public long Id { get; init; }

    public string Name { get; init; }

    public long VideoCount { get; init; }

    public DateTime DateCreated { get; init; }

    public string[] ReplicationRegions { get; init; }

    public string ApiKey { get; init; }

    public string ReadOnlyApiKey { get; init; }

    public bool HasWatermark { get; init; }

    public int WatermarkPositionLeft { get; init; }

    public int WatermarkPositionTop { get; init; }

    public int WatermarkWidth { get; init; }

    public int WatermarkHeight { get; init; }

    public long PullZoneId { get; init; }

    public string EnabledResolutions { get; init; }

#nullable enable

    public string? ViAiPublisherId { get; init; }

    public string? VastTagUrl { get; init; }

    public string? WebhookUrl { get; init; }

#nullable disable

    public int CaptionsFontSize { get; init; }

    public string CaptionsFontColor { get; init; }

    public string CaptionsBackground { get; init; }

    public string UILanguage { get; init; }

    public bool AllowEarlyPlay { get; init; }

    public bool PlayerTokenAuthenticationEnabled { get; init; }

    public string[] AllowedReferrers { get; init; }

    public string[] BlockedReferrers { get; init; }

    public bool BlockNoneReferrer { get; init; }

    public bool EnableMP4Fallback { get; init; }

    public bool KeepOriginalFiles { get; init; }

    public bool AllowDirectPlay { get; init; }

    public bool EnableDRM { get; init; }

    public int Bitrate240p { get; init; }

    public int Bitrate360p { get; init; }

    public int Bitrate480p { get; init; }

    public int Bitrate720p { get; init; }

    public int Bitrate1080p { get; init; }

    public int Bitrate1440p { get; init; }

    public int Bitrate2160p { get; init; }
}
