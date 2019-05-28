using Carbon.Json;
using Carbon.Json.Converters;

namespace BunnyCdn.Serialization
{
    internal sealed class EdgeRuleActionTypeJsonConverter : JsonConverter<EdgeRuleActionType>
    {
        public override EdgeRuleActionType FromJson(JsonNode node) => (EdgeRuleActionType)((int)node);
       
        public override JsonNode ToJson(EdgeRuleActionType value) => new JsonNumber((int)value);
    }
}