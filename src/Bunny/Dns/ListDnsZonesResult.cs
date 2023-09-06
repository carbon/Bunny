using System.Text.Json.Serialization;

namespace Bunny.Dns;

[method: JsonConstructor]
public sealed class ListDnsZonesResult(DnsZone[] items)
{
    public DnsZone[] Items { get; } = items;
}