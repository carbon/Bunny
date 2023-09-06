using System.Net;

namespace Bunny.Cdn;

public sealed class AddBlockedIpRequest(long pullZoneId, IPAddress blockedIp)
{
    public long PullZoneId { get; } = pullZoneId;

    public IPAddress BlockedIp { get; } = blockedIp ?? throw new ArgumentNullException(nameof(blockedIp));
}