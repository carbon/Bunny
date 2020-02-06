using Carbon.Json;
using Carbon.Json.Converters;

namespace BunnyCdn.Serialization
{
    internal sealed class EdgeRuleMatchTypeJsonConverter : JsonConverter<MatchType>
    {
        public override MatchType FromJson(JsonNode node) => (MatchType)((int)node);
       
        public override JsonNode ToJson(MatchType value) => new JsonNumber((int)value);
    }
}