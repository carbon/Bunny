using System.Net;

namespace Bunny.Cdn;

public sealed class AddBlockedIpRequest
{
    public AddBlockedIpRequest(long pullZoneId, IPAddress blockedIp)
    {
        ArgumentNullException.ThrowIfNull(blockedIp);

        PullZoneId = pullZoneId;
        BlockedIp = blockedIp;
    }

    public long PullZoneId { get; }

    public IPAddress BlockedIp { get; }
}