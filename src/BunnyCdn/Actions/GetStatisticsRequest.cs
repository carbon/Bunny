using System;

namespace BunnyCdn
{
    public sealed class GetStatisticsRequest
    {
        public GetStatisticsRequest(
            long? pullZoneId = null,
            long? serverZoneId = null,
            DateTime? start = null,
            DateTime? end = null)
        {
            PullZoneId = pullZoneId;
            ServerZoneId = serverZoneId;
            Start = start;
            End = end;
        }

        public long? PullZoneId { get; }

        public long? ServerZoneId { get; }

        // dateFrom
        public DateTime? Start { get; }

        // dateTo
        public DateTime? End { get; }
    }
}