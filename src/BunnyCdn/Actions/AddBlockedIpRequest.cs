using System;
using System.Net;

namespace BunnyCdn
{
    public sealed class AddBlockedIpRequest
    {
        public AddBlockedIpRequest(long pullZoneId, IPAddress blockedIp)
        {
            PullZoneId = pullZoneId;
            BlockedIp = blockedIp ?? throw new ArgumentNullException(nameof(blockedIp));
        }

        public long PullZoneId { get; }

        public IPAddress BlockedIp { get; }
    }
}