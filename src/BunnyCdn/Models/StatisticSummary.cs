#nullable disable

using BunnyCdn.Models;

namespace BunnyCdn
{
    public sealed class GetStatisticsResult
    {
        public double TotalBandwidthUsed { get; set; }

        public long TotalRequestsServed { get; set; }
        
        public double CacheHitRate { get; set; }

        public TimeSeriesDataset<long> BandwidthUsedChart { get; set; }

        public TimeSeriesDataset<long> BandwidthCachedChart { get; set; }
   
        public TimeSeriesDataset<double> CacheHitRateChart { get; set; }

        public TimeSeriesDataset<long> RequestsServedChart { get; set; }

        public TimeSeriesDataset<long> PullRequestsPulledChart { get; set; }

        public TimeSeriesDataset<double> UserBalanceHistoryChart { get; set; }

        public TimeSeriesDataset<long> UserStorageUsedChart { get; set; }

        public GeotrafficDistribution GeoTrafficDistribution { get; set; }

        public TimeSeriesDataset<long> Error3xxChart { get; set; }

        public TimeSeriesDataset<long> Error4xxChart { get; set; }

        public TimeSeriesDataset<long> Error5xxChart { get; set; }
    }
}