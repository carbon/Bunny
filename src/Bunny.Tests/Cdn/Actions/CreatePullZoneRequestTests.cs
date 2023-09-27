using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bunny.Cdn.Tests;

public class CreatePullZoneRequestTests
{
    private static readonly JsonSerializerOptions s_jso = new () {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    [Fact]
    public void CanConstruct()
    {
        var request = new CreatePullZoneRequest("name", "https://origin") { EnableTLS1 = false };

        Assert.Equal("name", request.Name);
        Assert.Equal("https://origin", request.OriginUrl);

        Assert.Equal("""{"Name":"name","OriginUrl":"https://origin","EnableTLS1":false}""", JsonSerializer.Serialize(request, s_jso));
    }
}