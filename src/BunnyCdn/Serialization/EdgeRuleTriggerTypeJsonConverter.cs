using Carbon.Json;
using Carbon.Json.Converters;

namespace BunnyCdn.Serialization
{
    internal sealed class EdgeRuleTriggerTypeJsonConverter : JsonConverter<EdgeRuleTriggerType>
    {
        public override EdgeRuleTriggerType FromJson(JsonNode node) => (EdgeRuleTriggerType)((int)node);
        
        public override JsonNode ToJson(EdgeRuleTriggerType value) => new JsonNumber((int)value);
    }
}