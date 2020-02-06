using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using BunnyCdn.Exceptions;
using BunnyCdn.Serialization;

using Carbon.Json;
using Carbon.Json.Converters;

namespace BunnyCdn
{
    public sealed partial class BunnyCdnClient
    {
        private const string baseUrl = "https://bunnycdn.com/api/";

        private readonly IBunnyCdnAccessKey accessKey;
        private readonly HttpClient http;

        static BunnyCdnClient()
        {
            try
            {
                JsonConverterFactory.Add(new LongDatasetJsonConverter());
                JsonConverterFactory.Add(new DoubleDatasetJsonConverter());
                JsonConverterFactory.Add(new GeotrafficDistributionJsonConverter());
                JsonConverterFactory.Add(new EdgeRuleActionTypeJsonConverter());
                JsonConverterFactory.Add(new EdgeRuleTriggerTypeJsonConverter());
                JsonConverterFactory.Add(new EdgeRuleMatchTypeJsonConverter());
            }
            catch
            { }
        }

        public BunnyCdnClient(string accessKey)
            : this(new BunnyCdnAccessKey(accessKey))
        { }

        public BunnyCdnClient(IBunnyCdnAccessKey accessKey)
            : this(accessKey, new HttpClient())
        {
            this.accessKey = accessKey;

            this.http = new HttpClient(new HttpClientHandler {
                AutomaticDecompression = DecompressionMethods.GZip
            });

            this.http.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
        }

        public BunnyCdnClient(IBunnyCdnAccessKey accessKey, HttpClient httpClient)
        {
            http = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            this.accessKey = accessKey;
        }

        #region Pull Zones

        public async Task<PullZone> GetPullZoneAsync(long id)
        {
            return await GetAsync<PullZone>(GetUrl("pullzone/" + id));
        }

        public async Task<PullZone[]> ListPullZonesAsync()
        {
            return await GetListAsync<PullZone>(GetUrl("pullzone"));
        }

        public async Task<PullZone> CreatePullZoneAsync(CreatePullZoneRequest request)
        {
            var (_, responseText) = await PostJsonAsync(GetUrl("pullzone"), request);

            return JsonObject.Parse(responseText).As<PullZone>();
        }

        public async Task SetEnabledVaryParametersAsync(SetEnabledVaryParametersRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/setEnabledVaryParameters"), request);
        }

        public async Task SetCacheFileSlicingEnabledAsync(SetCacheFileSlicingEnabledRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/setCacheFileSlicingEnabled"), request);
        }

        public async Task SetEnabledVaryParametersAsync(SetDisableCookiesEnabledRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/setDisableCookiesEnabled"), request);
        }

        public async Task SetCacheExpirationTimeAsync(SetCacheExpirationTimeRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/setCacheExpirationTime"), request);
        }

        public async Task DeletePullZoneAsync(long pullZoneId)
        {
            await DeleteAsync(GetUrl("pullzone/" + pullZoneId));
        }

        public async Task SetForceSslAsync(SetForceSslRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/setForceSSL"), request);
        }

        public async Task LoadFreeCertificateAsync(LoadFreeCertificateRequest request)
        {
            await GetAsync(GetUrl($"pullzone/loadFreeCertificate?hostname={UrlEncoder.Default.Encode(request.Hostname)}"));
        }

        public async Task AddCertificateAsync(AddCertificateRequest request)
        {
            await PostJsonAsync(GetUrl($"pullzone/addCertificate"), request);
        }

        public async Task<DownloadLogResult> DownloadLogAsync(DownloadLogRequest request)
        {
            string dateString = request.Date.ToString("MM-dd-yy");

            string url = "https://logging.bunnycdn.com/" + dateString + "/" + request.PullZoneId + ".log";

            var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Post, url));

            return new DownloadLogResult(response);
        }

        #endregion

        #region Hostnames

        public async Task AddHostnameAsync(AddHostnameRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/addHostname"), request);
        }

        public async Task DeleteHostnameAsync(DeleteHostnameRequest request)
        {
            await DeleteAsync(GetUrl($"pullzone/deleteHostname?id={request.PullZoneId}&hostname={UrlEncoder.Default.Encode(request.Hostname)}"));
        }

        #endregion

        #region Edge Rules

        public async Task AddOrUpdateEdgeRuleAsync(long pullZoneId, EdgeRule request)
        {
            await PostJsonAsync(GetUrl($"pullzone/{pullZoneId}/edgerules/addOrUpdate"), request);
        }

        public async Task DeleteEdgeRuleAsync(DeleteEdgeRuleRequest request)
        {
            await DeleteAsync(GetUrl($"pullzone/{request.PullZoneId}/edgerules/{request.EdgeRuleId}"));
        }

        #endregion

        #region Ips

        public async Task AddBlockedIpAsync(AddBlockedIpRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/addBlockedIp"), request);
        }

        public async Task RemoveBlockedIpAsync(AddBlockedIpRequest request)
        {
            await PostJsonAsync(GetUrl("pullzone/removeBlockedIp"), request);
        }

        #endregion

        #region Billing

        public async Task<BillingSummary> GetBillingSummaryAsync()
        {
            return await GetAsync<BillingSummary>(GetUrl("billing"));
        }
        #endregion

        #region Purging

        public async Task<bool> PurgeUrlAsync(Uri url)
        {
            string requestUrl = GetUrl("purge/?url=" + UrlEncoder.Default.Encode(url.AbsoluteUri));

            var (status, _) = await PostAsync(requestUrl);

            return status == HttpStatusCode.OK;
        }

        public async Task<bool> PurgePullZoneAsync(long pullZoneId)
        {
            await PostAsync(GetUrl(($"pullzone/{pullZoneId}/purgeCache")));

            return true;
        }

        #endregion

        #region Statistics

        public async Task<GetStatisticsResult> GetStatisticsAsync(GetStatisticsRequest request)
        {
            var paramaters = new Dictionary<string, string>();

            if (request.Start is DateTime start && request.End is DateTime end)
            {          
                paramaters.Add("dateFrom", start.ToString("yyyy-MM-dd"));
                paramaters.Add("dateTo", end.ToString("yyyy-MM-dd"));
            }

            if (request.PullZoneId is long pullZoneId)
            {
                paramaters.Add("pullZone", pullZoneId.ToString());
            }

            if (request.ServerZoneId is long serverZoneId)
            {
                paramaters.Add("serverZoneId", serverZoneId.ToString());
            }

            return await GetAsync<GetStatisticsResult>(GetUrl("statistics" + DictionaryHelper.ToQueryString(paramaters)));
        }

        #endregion

        public async Task<IPAddress[]> GetEdgeIpsAsync()
        {
            string url = "https://bunnycdn.com/api/system/edgeserverlist";

            string text = await http.GetStringAsync(url);

            var json = JsonArray.Parse(text);

            var servers = new IPAddress[json.Count];

            for (int i = 0; i < json.Count; i++)
            {
                servers[i] = IPAddress.Parse(json[i].ToString());
            }

            return servers;
        }

        private string GetUrl(string path) => baseUrl + path;

        private async Task<(HttpStatusCode, string)> GetAsync(string url)
        {
            return await SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
        }
   
        private async Task<(HttpStatusCode, string)> PostJsonAsync(string url, object data)   
        {
            return await SendAsync(new HttpRequestMessage(HttpMethod.Post, url) {
                Headers = {
                    { "Accept", "application/json" },
                },
                Content = new StringContent(JsonObject.FromObject(data).ToString(false), Encoding.UTF8, "application/json")
            });
        }

        private async Task<(HttpStatusCode, string)> DeleteAsync(string url)
        {
            return await SendAsync(new HttpRequestMessage(HttpMethod.Delete, url));
        }

        private async Task<(HttpStatusCode, string)> PostAsync(string url)
        {
            return await SendAsync(new HttpRequestMessage(HttpMethod.Post, url));
        }

        private async Task<(HttpStatusCode, string)> SendAsync(HttpRequestMessage message)
        {
            using HttpResponseMessage response = await SendMessageAsync(message);

            string responseText = response.Content != null 
                ? await response.Content.ReadAsStringAsync()
                : string.Empty;

            return (response.StatusCode, responseText);
        }

        private async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage message)
        {
            if (accessKey.ShouldRenew)
            {
                await accessKey.RenewAsync().ConfigureAwait(false);
            }

            message.Headers.Add("AccessKey", accessKey.Value);

            HttpResponseMessage response = await http.SendAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                string responseText = response.Content != null
                    ? await response.Content.ReadAsStringAsync() 
                    : string.Empty;

                response.Dispose();

                throw new BunnyCdnException(response.StatusCode, responseText);
            }
           
            return response;
        }

        private async Task<T> GetAsync<T>(string path)
            where T : new()
        {
            var (_, responseText) = await GetAsync(path);

            return JsonObject.Parse(responseText).As<T>();
        }

        private async Task<T[]> GetListAsync<T>(string path)
            where T : new()
        {
            var (_, responseText) = await GetAsync(path);

            return JsonArray.Parse(responseText).ToArrayOf<T>();
        }
    }
}