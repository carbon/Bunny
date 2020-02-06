using BunnyCdn.Models;

using Carbon.Data;
using Carbon.Json;
using Carbon.Json.Converters;

namespace BunnyCdn.Serialization
{
    internal sealed class DoubleDatasetJsonConverter : JsonConverter<TimeSeriesDataset<double>>
    {
        public override TimeSeriesDataset<double> FromJson(JsonNode node)
        {
            var obj = (JsonObject)node;

            var dic = new TimeSeriesDataset<double>(obj.Keys.Count);

            foreach (var property in obj)
            {
                dic.Add(IsoDate.Parse(property.Key).ToUtcDateTime(), (double)property.Value);
            }

            return dic;
        }

        public override JsonNode ToJson(TimeSeriesDataset<double> value)
        {
            var obj = new JsonObject(value.Count);

            foreach (var property in value)
            {
                obj.Add(IsoDate.FromDateTimeOffset(property.Key).ToString(), property.Value);
            }

            return obj;
        }
    }
}