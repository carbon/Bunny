using System.Text.Json;

namespace Bunny.Streaming.Tests;

public class VideoTests
{
    [Fact]
    public void CanDeserialize()
    {
        var result = JsonSerializer.Deserialize<Video>(
            """
            {
                "videoLibraryId":1,
                "guid":"23bcf56f-c221-4b65-ac22-bd076f47d027",
                "title":"T1",
                "dateUploaded":"2021-05-01T22:38:12.248",
                "views":0,
                "isPublic":false,
                "length":1123,
                "status":2,
                "framerate":23.976,
                "width":1280,
                "height":720,
                "availableResolutions":null,
                "thumbnailCount":0,
                "encodeProgress":56,
                "storageSize":0,
                "captions":[],
                "hasMP4Fallback":false,
                "collectionId":"",
                "thumbnailFileName":"thumbnail.jpg"
            }
            """);

        Assert.Equal(1, result.VideoLibraryId);
        Assert.Equal("", result.CollectionId);
        Assert.Equal(Guid.Parse("23bcf56f-c221-4b65-ac22-bd076f47d027"), result.Guid);

        Assert.Equal(23.976, result.Framerate);
        Assert.Equal(1280, result.Width);
        Assert.Equal(720, result.Height);

        Assert.Equal(1123, result.Length);
        Assert.Equal(2, result.Status);

        Assert.False(result.HasMp4Fallback);
        Assert.Equal("thumbnail.jpg", result.ThumbnailFileName);

        Assert.Equal(56, result.EncodeProgress);
    }
}