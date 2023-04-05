#nullable disable

using Bunny.Dns;

namespace Bunny.Cdn;

public sealed class ListDnsZonesResult
{
    public DnsZone[] Items { get; init; }
}