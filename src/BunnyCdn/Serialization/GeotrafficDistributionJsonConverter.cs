using Carbon.Json;
using Carbon.Json.Converters;

namespace BunnyCdn.Serialization
{
    internal sealed class GeotrafficDistributionJsonConverter : JsonConverter<GeotrafficDistribution>
    {
        public override GeotrafficDistribution FromJson(JsonNode node)
        {
            var obj = (JsonObject)node;

            var dic = new GeotrafficDistribution(obj.Keys.Count);

            foreach (var property in obj)
            {
                dic.Add(property.Key, (long)property.Value);
            }

            return dic;
        }

        public override JsonNode ToJson(GeotrafficDistribution value)
        {
            var obj = new JsonObject(value.Count);

            foreach (var property in value)
            {
                obj.Add(property.Key, property.Value);
            }

            return obj;
        }
    }
}