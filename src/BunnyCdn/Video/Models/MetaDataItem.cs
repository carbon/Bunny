using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BunnyCdn
{
    public class MetaDataItem
    {
        [JsonPropertyName("property")]
        public String Property { get; set; }

        [JsonPropertyName("value")]
        public String Value { get; set; }

    }
}
