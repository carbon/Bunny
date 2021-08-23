using System;
using System.Linq;
using System.Text.Json;

using Xunit;

namespace BunnyCdn.Tests
{
    public class GetStatisticsResultTests
    {
        [Fact]
        public void Roundtrip()
        {
            var r = JsonSerializer.Serialize(getStatisticsResult_data, JSO.Default);

            var b = JsonSerializer.Deserialize<BunnyCdn.GetStatisticsResult>(r);

            Assert.Equal(98.41, getStatisticsResult_data.CacheHitRate);
            Assert.Equal(getStatisticsResult_data.TotalBandwidthUsed, b.TotalBandwidthUsed);
            Assert.Equal(getStatisticsResult_data.BandwidthUsedChart.Count, b.BandwidthUsedChart.Count);

            Assert.Equal(21, b.TotalBandwidthUsed);
            Assert.Equal(21, b.BandwidthUsedChart.Sum(e => e.Value));
        }

        private static string GetDateString(DateTime date) => date.ToString("yyyy-MM-dd");
        
        private static readonly GetStatisticsResult getStatisticsResult_data = new () {
            TotalBandwidthUsed = 21,
            TotalRequestsServed = 20000,
            CacheHitRate = 98.41,
            BandwidthUsedChart = new () {
                { GetDateString(DateTime.UtcNow.AddDays(-5)), 1 },
                { GetDateString(DateTime.UtcNow.AddDays(-4)), 2 },
                { GetDateString(DateTime.UtcNow.AddDays(-3)), 3 },
                { GetDateString(DateTime.UtcNow.AddDays(-2)), 4 },
                { GetDateString(DateTime.UtcNow.AddDays(-1)), 5 },
                { GetDateString(DateTime.UtcNow),             6 },
            },          
         
            GeoTrafficDistribution = new GeotrafficDistribution {
                { "EU: London, UK",        1 },
                { "NA: Los Angeles, CA",   2 },
            }
           
        };
    }
}