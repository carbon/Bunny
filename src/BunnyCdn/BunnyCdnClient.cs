using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

using BunnyCdn.Exceptions;
using BunnyCdn.Serialization;

namespace BunnyCdn;

public sealed partial class BunnyCdnClient
{
    private const string baseUrl = "https://api.bunny.net/";

    private readonly IBunnyCdnAccessKey _accessKey;
    private readonly HttpClient _httpClient;

    private static readonly JsonSerializerOptions jso = new () {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public BunnyCdnClient(string accessKey)
        : this(new BunnyCdnAccessKey(accessKey))
    { }

    public BunnyCdnClient(IBunnyCdnAccessKey accessKey)
    {
        ArgumentNullException.ThrowIfNull(accessKey);

        _accessKey = accessKey;

        _httpClient = new HttpClient(new SocketsHttpHandler {
            AutomaticDecompression = DecompressionMethods.All,
            ConnectTimeout = TimeSpan.FromSeconds(10)
        })
        {  Timeout = TimeSpan.FromMinutes(6) };

        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
    }

    public BunnyCdnClient(IBunnyCdnAccessKey accessKey, HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        _accessKey = accessKey;
        _httpClient = httpClient;
    }

    #region Pull Zones

    public Task<PullZone> GetPullZoneAsync(long id)
    {
        return GetAsync<PullZone>(GetUrl($"pullzone/{id}"));
    }

    public Task<PullZone[]> ListPullZonesAsync()
    {
        return GetAsync<PullZone[]>(GetUrl("pullzone"));
    }

    public Task<PullZone> CreatePullZoneAsync(CreatePullZoneRequest request)
    {
        return PostJsonAsync<CreatePullZoneRequest, PullZone>(GetUrl("pullzone"), request);
    }

    public async Task SetEnabledVaryParametersAsync(SetEnabledVaryParametersRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setEnabledVaryParameters"), request).ConfigureAwait(false);
    }

    public async Task SetCacheFileSlicingEnabledAsync(SetCacheFileSlicingEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setCacheFileSlicingEnabled"), request).ConfigureAwait(false);
    }

    public async Task SetEnabledVaryParametersAsync(SetDisableCookiesEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setDisableCookiesEnabled"), request).ConfigureAwait(false);
    }

    public async Task SetCacheExpirationTimeAsync(SetCacheExpirationTimeRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setCacheExpirationTime"), request).ConfigureAwait(false);
    }

    public async Task DeletePullZoneAsync(long pullZoneId)
    {
        await DeleteAsync(GetUrl("pullzone/" + pullZoneId)).ConfigureAwait(false);
    }

    public async Task SetForceSslAsync(SetForceSslRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setForceSSL"), request).ConfigureAwait(false);
    }

    public async Task LoadFreeCertificateAsync(LoadFreeCertificateRequest request)
    {
        await GetAsync(GetUrl("pullzone/loadFreeCertificate?hostname=" + HttpUtility.UrlEncode(request.Hostname))).ConfigureAwait(false);
    }

    public async Task SetTlsSupport(SetTlsSupportRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setTlsSupport"), request).ConfigureAwait(false);
    }

    public async Task AddCertificateAsync(AddCertificateRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/addCertificate"), request).ConfigureAwait(false);
    }

    public async Task ResetSecurityKeyAsync(ResetSecurityKeyRequest request)
    {
        await PostAsync(GetUrl("pullzone/requestSecurityKey?pullZoneId=" + request.Id.ToString())).ConfigureAwait(false);
    }

    public async Task SetZoneSecurityEnabledAsync(SetZoneSecurityEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setZoneSecurityEnabled"), request).ConfigureAwait(false);
    }

    public async Task SetZoneSecurityIncludeHashRemoteIpEnabled(SetZoneSecurityIncludeHashRemoteIPEnabledRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/setZoneSecurityIncludeHashRemoteIPEnabled"), request).ConfigureAwait(false);
    }

    public async Task<DownloadLogResult> DownloadLogAsync(DownloadLogRequest request)
    {
        const string loggingUri = "https://logging.bunnycdn.com/";

        string url = string.Create(CultureInfo.InvariantCulture, $"{loggingUri}/{request.Date:MM-dd-yy}/{request.PullZoneId}.log");

        var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Post, url)).ConfigureAwait(false);

        return new DownloadLogResult(response);
    }

    #endregion

    #region Hostnames

    public async Task AddHostnameAsync(AddHostnameRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/addHostname"), request).ConfigureAwait(false);
    }

    public async Task DeleteHostnameAsync(DeleteHostnameRequest request)
    {
        await DeleteAsync(GetUrl($"pullzone/deleteHostname?id={request.PullZoneId}&hostname={HttpUtility.UrlEncode(request.Hostname)}")).ConfigureAwait(false);
    }

    #endregion

    #region Edge Rules

    public async Task AddOrUpdateEdgeRuleAsync(long pullZoneId, EdgeRule request)
    {
        await PostJsonAsync(GetUrl($"pullzone/{pullZoneId}/edgerules/addOrUpdate"), request).ConfigureAwait(false);
    }

    public async Task DeleteEdgeRuleAsync(DeleteEdgeRuleRequest request)
    {
        await DeleteAsync(GetUrl($"pullzone/{request.PullZoneId}/edgerules/{request.EdgeRuleId}")).ConfigureAwait(false);
    }

    #endregion

    #region Ips

    public async Task AddBlockedIpAsync(AddBlockedIpRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/addBlockedIp"), request).ConfigureAwait(false);
    }

    public async Task RemoveBlockedIpAsync(AddBlockedIpRequest request)
    {
        await PostJsonAsync(GetUrl("pullzone/removeBlockedIp"), request).ConfigureAwait(false);
    }

    #endregion

    #region Billing

    public async Task<BillingSummary> GetBillingSummaryAsync()
    {
        return await GetAsync<BillingSummary>(GetUrl("billing")).ConfigureAwait(false);
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
        await PostAsync(GetUrl("purge?url=" + HttpUtility.UrlEncode(url))).ConfigureAwait(false);

        return true;
    }

    public async Task<bool> PurgePullZoneAsync(long pullZoneId)
    {
        await PostAsync(GetUrl($"pullzone/{pullZoneId}/purgeCache")).ConfigureAwait(false);

        return true;
    }

    #endregion

    #region Statistics

    public async Task<GetStatisticsResult> GetStatisticsAsync(GetStatisticsRequest request)
    {
        var paramaters = new Dictionary<string, string>(4);

        if (request.Start is DateTime start && request.End is DateTime end)
        {          
            paramaters.Add("dateFrom", start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            paramaters.Add("dateTo", end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }

        if (request.PullZoneId is long pullZoneId)
        {
            paramaters.Add("pullZone", pullZoneId.ToString(CultureInfo.InvariantCulture));
        }

        if (request.ServerZoneId is long serverZoneId)
        {
            paramaters.Add("serverZoneId", serverZoneId.ToString(CultureInfo.InvariantCulture));
        }

        return await GetAsync<GetStatisticsResult>(GetUrl("statistics" + DictionaryHelper.ToQueryString(paramaters))).ConfigureAwait(false);
    }

    #endregion


    #region Video Libraries


    public Task<VideoLibrary[]> ListVideoLibrariesAsync()
    {
        return GetAsync<VideoLibrary[]>(new Uri(baseUrl + "videolibrary"));
    }

    public Task<VideoLibrary> GetVideoLibraryAsync(long id)
    {
        var url = baseUrl + "videolibrary/" + id.ToString(CultureInfo.InvariantCulture);

        return GetAsync<VideoLibrary>(new Uri(url));
    }

    #endregion
    public async Task<IPAddress[]> GetEdgeIpsAsync()
    {
        const string url = "https://api.bunny.net/system/edgeserverlist";

        var request = new HttpRequestMessage(HttpMethod.Get, url) {
            Headers = { { "Accept", "application/json" } }
        };

        using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);

        var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

        var json = (await JsonSerializer.DeserializeAsync<string[]>(responseStream).ConfigureAwait(false))!;

        var servers = new IPAddress[json.Length];

        for (int i = 0; i < json.Length; i++)
        {
            servers[i] = IPAddress.Parse(json[i]);
        }

        return servers;
    }

    private static Uri GetUrl(string path) => new (baseUrl + path);

    private async Task GetAsync(Uri url)
    {
        using var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Get, url)).ConfigureAwait(false);
    }
   
    private async Task<TResult> PostJsonAsync<TRequest, TResult>(Uri url, TRequest data)   
    {
        byte[] json = JsonSerializer.SerializeToUtf8Bytes(data, jso);

        var message = new HttpRequestMessage(HttpMethod.Post, url) {
            Headers = {
                { "Accept", "application/json" },
            },
            Content = new ByteArrayContent(json) {
                Headers = { { "Content-Type", "application/json" } }
            }
        };

        using HttpResponseMessage response = await SendMessageAsync(message).ConfigureAwait(false);

        using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

        return (await JsonSerializer.DeserializeAsync<TResult>(responseStream).ConfigureAwait(false))!;
    }

    private async Task PostJsonAsync<TRequest>(Uri url, TRequest data)
    {
        byte[] json = JsonSerializer.SerializeToUtf8Bytes(data, jso);

        var message = new HttpRequestMessage(HttpMethod.Post, url) {
            Headers = {
                { "Accept", "application/json" },
            },
            Content = new ByteArrayContent(json) {
                Headers = { 
                    { "Content-Type", "application/json" }
                }
            }
        };

        using HttpResponseMessage response = await SendMessageAsync(message).ConfigureAwait(false);     
    }

    private async Task DeleteAsync(Uri url)
    {
        using var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Delete, url)).ConfigureAwait(false);
    }

    private async Task PostAsync(Uri url)
    {
        using var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Post, url)).ConfigureAwait(false);
    }

    private async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request)
    {
        if (_accessKey.ShouldRenew)
        {
            await _accessKey.RenewAsync().ConfigureAwait(false);
        }

        request.Headers.Add("AccessKey", _accessKey.Value);

        HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            string responseText = response.Content is not null
                ? await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                : string.Empty;

            response.Dispose();

            if (responseText.StartsWith('{'))
            {
                var error = JsonSerializer.Deserialize<BunnyCdnError>(responseText);

                if (error?.Message is not null)
                {
                    throw new BunnyCdnException(response.StatusCode, error!);
                }
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new BunnyCdnException(response.StatusCode, "Unauthorized");

            }

            throw new BunnyCdnException(response.StatusCode, responseText);
        }
           
        return response;
    }

    private async Task<T> GetAsync<T>(Uri url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        using var response = await SendMessageAsync(request).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            throw new Exception(responseText);
        }

        using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

        var jsonResult = await JsonSerializer.DeserializeAsync<T>(responseStream).ConfigureAwait(false);

        return jsonResult!;
    }
}