#nullable disable

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BunnyCdn.Exceptions
{
    public sealed class BunnyCdnProblem
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("errors")]
        public Dictionary<string, string[]> Errors { get; set; }

        // "errors":{"Title":["The Title field is required."]
    }
}


// {"type":"https://tools.ietf.org/html/rfc7231#section-6.5.1","title":"One or more validation errors occurred.","status":400,"traceId":"|2c7f2701-4f990170eea311ff.","errors":{"Title":["The Title field is required."]}}

