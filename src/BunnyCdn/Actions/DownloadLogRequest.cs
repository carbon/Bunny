namespace BunnyCdn
{
    public sealed class DownloadLogRequest
    {
        public DownloadLogRequest(long pullZoneId, DateTime date)
        {
            PullZoneId = pullZoneId;
            Date = date;
        }

        public long PullZoneId { get; }

        public DateTime Date { get; }
    }
}