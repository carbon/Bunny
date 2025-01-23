#nullable disable

namespace Bunny.Cdn;

public sealed class GetStatisticsResult
{
    public required long TotalBandwidthUsed { get; init; }

    public required long TotalRequestsServed { get; init; }

    public required int AverageOriginResponseTime { get; init; }

    public required double CacheHitRate { get; init; }

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