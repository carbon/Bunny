using System;

namespace BunnyCdn
{
    public sealed class DeleteHostnameRequest
    {
        public DeleteHostnameRequest(long pullZoneId, string hostname)
        {
            PullZoneId = pullZoneId;
            Hostname = hostname ?? throw new ArgumentNullException(nameof(hostname));
        }

        public long PullZoneId { get; }

        public string Hostname { get; }
    }
}