using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Web;

using Bunny.Serialization;

namespace Bunny.Cdn;

public sealed class BunnyCdnClient : BunnyApiClient
{
    public BunnyCdnClient(string accessKey)
        : base(new BunnyAccessKey(accessKey))
    { }

    public BunnyCdnClient(IBunnyAccessKey accessKey, HttpClient httpClient)
        : base(accessKey, httpClient)
    { }

    #region Pull Zones

    public Task<PullZone> GetPullZoneAsync(long id)
    {
        return GetAsync<PullZone>(GetUrl($"/pullzone/{id}"));
    }

    public Task<PullZone[]> ListPullZonesAsync()
    {
        return GetAsync<PullZone[]>(GetUrl("/pullzone"));
    }

    public Task<PullZone> CreatePullZoneAsync(CreatePullZoneRequest request)
    {
        return PostJsonAsync<CreatePullZoneRequest, PullZone>(GetUrl("/pullzone"), request);
    }

    public async Task SetEnabledVaryParametersAsync(SetEnabledVaryParametersRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setEnabledVaryParameters"), request).ConfigureAwait(false);
    }

    public async Task SetCacheFileSlicingEnabledAsync(SetCacheFileSlicingEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setCacheFileSlicingEnabled"), request).ConfigureAwait(false);
    }

    public async Task SetEnabledVaryParametersAsync(SetDisableCookiesEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setDisableCookiesEnabled"), request).ConfigureAwait(false);
    }

    public async Task SetCacheExpirationTimeAsync(SetCacheExpirationTimeRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setCacheExpirationTime"), request).ConfigureAwait(false);
    }

    public async Task DeletePullZoneAsync(long pullZoneId)
    {
        await DeleteAsync(GetUrl($"/pullzone/{pullZoneId}")).ConfigureAwait(false);
    }

    public async Task SetForceSslAsync(SetForceSslRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setForceSSL"), request).ConfigureAwait(false);
    }

    public async Task LoadFreeCertificateAsync(LoadFreeCertificateRequest request)
    {
        await GetAsync(GetUrl("/pullzone/loadFreeCertificate?hostname=" + HttpUtility.UrlEncode(request.Hostname))).ConfigureAwait(false);
    }

    public async Task SetTlsSupport(SetTlsSupportRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setTlsSupport"), request).ConfigureAwait(false);
    }

    public async Task AddCertificateAsync(AddCertificateRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/addCertificate"), request).ConfigureAwait(false);
    }

    public async Task ResetSecurityKeyAsync(ResetSecurityKeyRequest request)
    {
        await PostAsync(GetUrl($"/pullzone/requestSecurityKey?pullZoneId={request.Id}")).ConfigureAwait(false);
    }

    public async Task SetZoneSecurityEnabledAsync(SetZoneSecurityEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setZoneSecurityEnabled"), request).ConfigureAwait(false);
    }

    public async Task SetZoneSecurityIncludeHashRemoteIpEnabled(SetZoneSecurityIncludeHashRemoteIPEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/setZoneSecurityIncludeHashRemoteIPEnabled"), request).ConfigureAwait(false);
    }

    public async Task<DownloadLogResult> DownloadLogAsync(DownloadLogRequest request)
    {
        string url = string.Create(CultureInfo.InvariantCulture, $"https://logging.bunnycdn.com/{request.Date:MM-dd-yy}/{request.PullZoneId}.log");

        var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Post, url)).ConfigureAwait(false);

        return new DownloadLogResult(response);
    }

    #endregion

    #region Hostnames

    public async Task AddHostnameAsync(AddHostnameRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/addHostname"), request).ConfigureAwait(false);
    }

    public async Task DeleteHostnameAsync(DeleteHostnameRequest request)
    {
        await DeleteAsync(GetUrl($"/pullzone/deleteHostname?id={request.PullZoneId}&hostname={HttpUtility.UrlEncode(request.Hostname)}")).ConfigureAwait(false);
    }

    #endregion

    #region Edge Rules

    public async Task AddOrUpdateEdgeRuleAsync(long pullZoneId, EdgeRule request)
    {
        await PostJsonAsync(GetUrl($"/pullzone/{pullZoneId}/edgerules/addOrUpdate"), request).ConfigureAwait(false);
    }

    public async Task DeleteEdgeRuleAsync(DeleteEdgeRuleRequest request)
    {
        await DeleteAsync(GetUrl($"/pullzone/{request.PullZoneId}/edgerules/{request.EdgeRuleId}")).ConfigureAwait(false);
    }

    #endregion

    #region Ips

    public async Task AddBlockedIpAsync(AddBlockedIpRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/addBlockedIp"), request).ConfigureAwait(false);
    }

    public async Task RemoveBlockedIpAsync(AddBlockedIpRequest request)
    {
        await PostJsonAsync(GetUrl("/pullzone/removeBlockedIp"), request).ConfigureAwait(false);
    }

    #endregion

    #region Billing

    public async Task<BillingSummary> GetBillingSummaryAsync()
    {
        return await GetAsync<BillingSummary>(GetUrl("/billing")).ConfigureAwait(false);
    }

    #endregion

    #region Purging

    public Task<bool> PurgeUrlAsync(Uri url)
    {
        ArgumentNullException.ThrowIfNull(url);

        return PurgeUrlAsync(url.ToString());
    }

    public async Task<bool> PurgeUrlAsync(string url)
    {
        await PostAsync(GetUrl("/purge?url=" + HttpUtility.UrlEncode(url))).ConfigureAwait(false);

        return true;
    }

    public async Task<bool> PurgePullZoneAsync(long pullZoneId)
    {
        await PostAsync(GetUrl($"/pullzone/{pullZoneId}/purgeCache")).ConfigureAwait(false);

        return true;
    }

    #endregion

    #region Statistics

    public async Task<GetStatisticsResult> GetStatisticsAsync(GetStatisticsRequest request)
    {
        var parameters = new Dictionary<string, string>(4);

        if (request.Start is DateTime start && request.End is DateTime end)
        {          
            parameters.Add("dateFrom", start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            parameters.Add("dateTo", end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }

        if (request.PullZoneId is long pullZoneId)
        {
            parameters.Add("pullZone", pullZoneId.ToString(CultureInfo.InvariantCulture));
        }

        if (request.ServerZoneId is long serverZoneId)
        {
            parameters.Add("serverZoneId", serverZoneId.ToString(CultureInfo.InvariantCulture));
        }

        return await GetAsync<GetStatisticsResult>(GetUrl("/statistics" + DictionaryHelper.ToQueryString(parameters))).ConfigureAwait(false);
    }

    #endregion

    #region Video Libraries

    public Task<VideoLibrary[]> ListVideoLibrariesAsync()
    {
        return GetAsync<VideoLibrary[]>(new Uri($"{baseUrl}/videolibrary"));
    }

    public Task<VideoLibrary> GetVideoLibraryAsync(long id)
    {
        var url = string.Create(CultureInfo.InvariantCulture, $"{baseUrl}/videolibrary/{id}");

        return GetAsync<VideoLibrary>(new Uri(url));
    }

    public Task<VideoLibrary> AddVideoLibraryAsync(String name)
    {
        var url = new Uri($"{baseUrl}/videolibrary");

        return PostJsonAsync<object, VideoLibrary>(url, new { name });
    }

    #endregion

    public async Task<IPAddress[]> GetEdgeIpsAsync()
    {
        const string url = "https://api.bunny.net/system/edgeserverlist";

        var request = new HttpRequestMessage(HttpMethod.Get, url) {
            Headers = { { "Accept", MediaTypeNames.Application.Json } }
        };

        using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);

        var json = await response.Content.ReadFromJsonAsync<string[]>(JsonSerializerOptions.Default).ConfigureAwait(false);

        var servers = new IPAddress[json!.Length];

        for (uint i = 0; i < (uint)json.Length; i++)
        {
            servers[i] = IPAddress.Parse(json[i]);
        }

        return servers;
    }
}