#nullable disable

using System.Collections.Generic;

namespace BunnyCdn
{
    public sealed class GetStatisticsResult
    {
        public double TotalBandwidthUsed { get; set; }

        public long TotalRequestsServed { get; set; }
        
        public double CacheHitRate { get; set; }

        public Dictionary<string, long> BandwidthUsedChart { get; set; }

        public Dictionary<string, long> BandwidthCachedChart { get; set; }
   
        public Dictionary<string, double> CacheHitRateChart { get; set; } 

        public Dictionary<string, long> RequestsServedChart { get; set; }

        public Dictionary<string, long> PullRequestsPulledChart { get; set; }

        public Dictionary<string, double> UserBalanceHistoryChart { get; set; }

        public Dictionary<string, long> UserStorageUsedChart { get; set; }

        public Dictionary<string, long> GeoTrafficDistribution { get; set; }

        public Dictionary<string, long> Error3xxChart { get; set; }

        public Dictionary<string, long> Error4xxChart { get; set; }

        public Dictionary<string, long> Error5xxChart { get; set; }
    }
}