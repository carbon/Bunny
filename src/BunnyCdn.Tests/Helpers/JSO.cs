using System.Text.Json;
using System.Text.Json.Serialization;

namespace BunnyCdn
{
    public static class JSO
    {
        public static readonly JsonSerializerOptions Default = new() { 
            WriteIndented = true, 
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }
}
