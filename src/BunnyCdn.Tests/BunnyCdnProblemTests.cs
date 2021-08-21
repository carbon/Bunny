using System.Text.Json;

using BunnyCdn.Exceptions;

using Xunit;

namespace BunnyCdn.Tests
{
    public class BunnyCdnProblemTests
    {
        [Fact]
        public void Deserialize()
        {
            string json = @"{
                ""type"":""https://tools.ietf.org/html/rfc7231#section-6.5.1"",
                ""title"":""One or more validation errors occurred."",
                ""status"":400,
                ""traceId"":""|2c7f2701-4f990170eea311ff."",
                ""errors"":{
                    ""Title"":[""The Title field is required.""]
                }
            }";

            var result = JsonSerializer.Deserialize<BunnyCdnProblem>(json);

            Assert.Equal("https://tools.ietf.org/html/rfc7231#section-6.5.1", result.Type);
            Assert.Equal("One or more validation errors occurred.", result.Title);
            Assert.Equal(400, result.Status);
            Assert.Equal("The Title field is required.", result.Errors["Title"][0]);
        }
    }
}