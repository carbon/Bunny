using System.Net;

namespace BunnyCdn
{
    public sealed class RemoveBlockedIpRequest
    {
        public RemoveBlockedIpRequest(long pullZoneId, IPAddress blockedIp)
        {
            PullZoneId = pullZoneId;
            BlockedIp = blockedIp;

        }
        public long PullZoneId { get; }

        public IPAddress BlockedIp { get; }
    }
}