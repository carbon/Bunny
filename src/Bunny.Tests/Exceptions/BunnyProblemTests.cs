using System.Text.Json;

namespace Bunny.Exceptions.Tests;

public class BunnyProblemTests
{
    [Fact]
    public void CanDeserialize()
    {
        var result = JsonSerializer.Deserialize<BunnyProblem>(
            """
            {
                "type":"https://tools.ietf.org/html/rfc7231#section-6.5.1",
                "title":"One or more validation errors occurred.",
                "status":400,
                "traceId":"|2c7f2701-4f990170eea311ff.",
                "errors":{
                    "Title":["The Title field is required."]
                }
            }
            """u8);

        Assert.Equal("https://tools.ietf.org/html/rfc7231#section-6.5.1", result.Type);
        Assert.Equal("One or more validation errors occurred.", result.Title);
        Assert.Equal(400, result.Status);
        Assert.Equal("The Title field is required.", result.Errors["Title"][0]);
    }
}