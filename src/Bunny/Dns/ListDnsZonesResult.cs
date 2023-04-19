using System.Text.Json.Serialization;

namespace Bunny.Dns;

public sealed class ListDnsZonesResult
{
    [JsonConstructor]
    public ListDnsZonesResult(DnsZone[] items)
    {
        Items = items;
    }

    public DnsZone[] Items { get; }
}