using System.Text.Json;

using Bunny.Cdn;

namespace Bunny.Streaming.Tests;

public class VideoLibraryTests
{
    [Fact]
    public void CanDeserialize()
    {
        var libraries = JsonSerializer.Deserialize<VideoLibrary[]>(
            """
            [
                {
                    "Id":1,
                    "Name":"test1",
                    "VideoCount":0,
                    "DateCreated":"2021-03-25T20:24:07",
                    "ReplicationRegions":["NY","LA","SG"],
                    "ApiKey":"x",
                    "ReadOnlyApiKey":"x",
                    "HasWatermark":false,
                    "WatermarkPositionLeft":0,
                    "WatermarkPositionTop":0,
                    "WatermarkWidth":0,
                    "PullZoneId":2,
                    "WatermarkHeight":0,
                    "EnabledResolutions":"240p,360p,480p,720p,1080p,1440p,2160p",
                    "ViAiPublisherId":null,
                    "VastTagUrl":null,
                    "WebhookUrl":null,
                    "CaptionsFontSize":20,
                    "CaptionsFontColor":"#fff",
                    "CaptionsBackground":"#000",
                    "UILanguage":"en",
                    "AllowEarlyPlay":false,
                    "PlayerTokenAuthenticationEnabled":false,
                    "AllowedReferrers":[],
                    "BlockedReferrers":[],
                    "BlockNoneReferrer":true,
                    "EnableMP4Fallback":true,
                    "KeepOriginalFiles":true,
                    "AllowDirectPlay":true,
                    "EnableDRM":false,
                    "Bitrate240p":600,
                    "Bitrate360p":800,
                    "Bitrate480p":1400,
                    "Bitrate720p":2800,
                    "Bitrate1080p":5000,
                    "Bitrate1440p":8000,
                    "Bitrate2160p":13000
                }
            ]
            """);

        var l0 = libraries[0];

        Assert.Equal(1, l0.Id);
        Assert.Equal("test1", l0.Name);
        Assert.Equal(0, l0.VideoCount);
        Assert.Equal(2021, l0.DateCreated.Year);
        Assert.Equal(["NY", "LA", "SG"], l0.ReplicationRegions.AsSpan());
        Assert.Equal("240p,360p,480p,720p,1080p,1440p,2160p", l0.EnabledResolutions);
        Assert.True(l0.BlockNoneReferrer);
        Assert.Equal("x", l0.ReadOnlyApiKey);
        Assert.True(l0.AllowDirectPlay);
        Assert.True(l0.KeepOriginalFiles);
        Assert.Equal(2, l0.PullZoneId);
        Assert.Equal(600, l0.Bitrate240p);
        Assert.Equal(800, l0.Bitrate360p);
        Assert.Equal(1400, l0.Bitrate480p);
        Assert.Equal(2800, l0.Bitrate720p);
        Assert.Equal(5000, l0.Bitrate1080p);
        Assert.Equal(8000, l0.Bitrate1440p);
        Assert.Equal(13000, l0.Bitrate2160p);
    }
}