using System.Globalization;
using System.Net.Http;

using Bunny.Cdn;

namespace Bunny.Dns;

public sealed class BunnyDnsClient : BunnyApiClient
{
    public BunnyDnsClient(IBunnyAccessKey accessKey)
        : base(accessKey) { }

    public BunnyDnsClient(IBunnyAccessKey accessKey, HttpClient httpClient)
        : base(accessKey, httpClient) { }

    public Task<ListDnsZonesResult> ListDnsZonesAsync()
    {
        var url = new Uri($"{baseUrl}/dnszone");

        return GetAsync<ListDnsZonesResult>(url);
    }

    public async Task DeleteDnsRecordAsync(long zoneId, long recordId)
    {
        var url = new Uri($"{baseUrl}/dnszone/{zoneId}/records/{recordId}");

        await DeleteAsync(url);
    }

    public async Task DeleteDnsZoneAsync(long zoneId)
    {
        var url = new Uri(string.Create(CultureInfo.InvariantCulture, $"{baseUrl}/dnszone/{zoneId}"));

        await DeleteAsync(url);
    }
}