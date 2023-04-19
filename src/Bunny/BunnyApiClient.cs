using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Bunny.Exceptions;

namespace Bunny.Cdn;

public abstract class BunnyApiClient
{
    protected const string baseUrl = "https://api.bunny.net";

    private readonly IBunnyAccessKey _accessKey;
    protected readonly HttpClient _httpClient;

    public BunnyApiClient(IBunnyAccessKey accessKey, HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(accessKey);
        ArgumentNullException.ThrowIfNull(httpClient);

        _accessKey = accessKey;
        _httpClient = httpClient;
    }

    public BunnyApiClient(IBunnyAccessKey accessKey)
    {
        ArgumentNullException.ThrowIfNull(accessKey);

        _accessKey = accessKey;

        _httpClient = new HttpClient(new SocketsHttpHandler {
            AutomaticDecompression = DecompressionMethods.All,
            ConnectTimeout = TimeSpan.FromSeconds(10)
        }) {
            Timeout = TimeSpan.FromMinutes(15)
        };

        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
    }

    private static readonly JsonSerializerOptions s_jso = new() {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    protected static Uri GetUrl(string path) => new(baseUrl + path);

    protected async Task GetAsync(Uri url)
    {
        using var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Get, url)).ConfigureAwait(false);
    }

    protected async Task<TResult> PostJsonAsync<TRequest, TResult>(Uri url, TRequest data)
    {
        byte[] json = JsonSerializer.SerializeToUtf8Bytes(data, s_jso);

        var message = new HttpRequestMessage(HttpMethod.Post, url) {
            Headers = {
                { "Accept", MediaTypeNames.Application.Json },
            },
            Content = new ByteArrayContent(json) {
                Headers = { { "Content-Type", MediaTypeNames.Application.Json } }
            }
        };

        using HttpResponseMessage response = await SendMessageAsync(message).ConfigureAwait(false);

        var result = await response.Content.ReadFromJsonAsync<TResult>(JsonSerializerOptions.Default).ConfigureAwait(false);

        return result!;
    }

    protected async Task PostJsonAsync<TRequest>(Uri url, TRequest data)
    {
        byte[] json = JsonSerializer.SerializeToUtf8Bytes(data, s_jso);

        var message = new HttpRequestMessage(HttpMethod.Post, url) {
            Headers = {
                { "Accept", MediaTypeNames.Application.Json },
            },
            Content = new ByteArrayContent(json) {
                Headers = {
                    { "Content-Type", MediaTypeNames.Application.Json }
                }
            }
        };

        using HttpResponseMessage response = await SendMessageAsync(message).ConfigureAwait(false);
    }

    protected async Task DeleteAsync(Uri url)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url);

        using var response = await SendMessageAsync(request).ConfigureAwait(false);
    }

    protected async Task PostAsync(Uri url)
    {
        using var response = await SendMessageAsync(new HttpRequestMessage(HttpMethod.Post, url)).ConfigureAwait(false);
    }

    protected async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request)
    {
        if (_accessKey.ShouldRenew)
        {
            await _accessKey.RenewAsync().ConfigureAwait(false);
        }

        request.Headers.Add("AccessKey", _accessKey.Value);

        HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            byte[] responseBytes = response.Content is not null
                ? await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false)
                : Array.Empty<byte>();

            response.Dispose();

            if (responseBytes is [(byte)'{', ..])
            {
                var error = JsonSerializer.Deserialize<BunnyError>(responseBytes);

                if (error?.Message is not null)
                {
                    throw new BunnyException(response.StatusCode, error!);
                }
            }

            if (response.StatusCode is HttpStatusCode.Unauthorized)
            {
                throw new BunnyException(response.StatusCode, "Unauthorized");
            }

            string responseText = responseBytes.Length > 0
                ? Encoding.UTF8.GetString(responseBytes)
                : response.StatusCode.ToString();

            throw new BunnyException(response.StatusCode, responseText);
        }

        return response;
    }

    protected async Task<T> GetAsync<T>(Uri url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        using var response = await SendMessageAsync(request).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            throw new Exception(responseText);
        }

        var result = await response.Content.ReadFromJsonAsync<T>(JsonSerializerOptions.Default).ConfigureAwait(false);

        return result!;
    }
}
