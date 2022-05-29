using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BunnyCdn
{
    public class VideoUploadResult
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public String Message { get; set; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

    }
}
