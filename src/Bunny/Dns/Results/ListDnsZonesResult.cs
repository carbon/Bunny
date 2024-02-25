namespace Bunny.Dns;

public sealed class ListDnsZonesResult
{
    public required DnsZone[] Items { get; init; }
}