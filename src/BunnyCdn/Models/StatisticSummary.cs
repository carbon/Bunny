#nullable disable

using System.Collections.Generic;

namespace BunnyCdn;

public sealed class GetStatisticsResult
{
    public double TotalBandwidthUsed { get; init; }

    public long TotalRequestsServed { get; init; }

    public double CacheHitRate { get; init; }

    public Dictionary<string, long> BandwidthUsedChart { get; init; }

    public Dictionary<string, long> BandwidthCachedChart { get; init; }

    public Dictionary<string, double> CacheHitRateChart { get; init; }

    public Dictionary<string, long> RequestsServedChart { get; init; }

    public Dictionary<string, long> PullRequestsPulledChart { get; init; }

    public Dictionary<string, double> UserBalanceHistoryChart { get; init; }

    public Dictionary<string, long> UserStorageUsedChart { get; init; }

    public Dictionary<string, long> GeoTrafficDistribution { get; init; }

    public Dictionary<string, long> Error3xxChart { get; init; }

    public Dictionary<string, long> Error4xxChart { get; init; }

    public Dictionary<string, long> Error5xxChart { get; init; }
}
