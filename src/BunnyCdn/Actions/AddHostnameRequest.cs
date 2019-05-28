using System;

namespace BunnyCdn
{
    public sealed class AddHostnameRequest
    {
        public AddHostnameRequest(long pullZoneId, string hostname)
        {
            PullZoneId = pullZoneId;
            Hostname = hostname ?? throw new ArgumentNullException(nameof(hostname));
        }

        public long PullZoneId { get; }

        public string Hostname { get; }
    }
}