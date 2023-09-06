using System.Net;

namespace Bunny.Cdn;

public sealed class RemoveBlockedIpRequest(long pullZoneId, IPAddress blockedIp)
{
    public long PullZoneId { get; } = pullZoneId;

    public IPAddress BlockedIp { get; } = blockedIp;
}