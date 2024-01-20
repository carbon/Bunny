namespace Bunny.Cdn;

public sealed class GetStatisticsRequest(
    long? pullZoneId = null,
    long? serverZoneId = null,
    DateTime? start = null,
    DateTime? end = null)
{
    public long? PullZoneId { get; } = pullZoneId;

    public long? ServerZoneId { get; } = serverZoneId;

    // dateFrom
    public DateTime? Start { get; } = start;

    // dateTo
    public DateTime? End { get; } = end;
}