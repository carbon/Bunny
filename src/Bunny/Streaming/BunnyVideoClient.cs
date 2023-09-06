using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;

using Bunny.Exceptions;

namespace Bunny.Streaming;

public sealed class BunnyVideoClient
{
    private const string baseUri = "https://video.bunnycdn.com";

    private readonly HttpClient _httpClient = new () {
        Timeout = TimeSpan.FromMinutes(10) 
    };

    private readonly string _accessKey;

    public BunnyVideoClient(string accessKey)
    {
        ArgumentNullException.ThrowIfNull(accessKey);

        _accessKey = accessKey;
    }

    public Task<Video> CreateVideoAsync(CreateVideoRequest request) 
    {
        string url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{request.LibraryId}/videos");

        return PostJsonAsync<CreateVideoRequest, Video>(url, request);
    }

    /*
    public async Task<UploadVideoResult> UploadVideoAsync(long libraryId, Guid videoId, byte[] fileContent)
    {
        string url = $"{baseUri}/library/{libraryId}/videos/{videoId}";

        var requestMessage = new HttpRequestMessage(HttpMethod.Put, url)
        {
            Content = new ByteArrayContent(fileContent) {
                Headers = { { "Content-Type", "application/json" } }
            }
        };

        using var response = await SendMessageAsync(requestMessage).ConfigureAwait(false);

        var result = await response.Content.ReadFromJsonAsync<UploadVideoResult>(s_jso);

        return result!;
    }
    */

    public async Task FetchVideoAsync(FetchVideoRequest request) 
    {
        string url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{request.LibraryId}/videos/{request.VideoId}/fetch");

        // {"success":true,"message":"OK","statusCode":200}

        await PostJsonAsync(url, request).ConfigureAwait(false);
    }

    public async Task<Video> GetVideoAsync(long libraryId, Guid videoId)
    {
        string url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{libraryId}/videos/{videoId}");

        return await GetJsonAsync<Video>(url).ConfigureAwait(false);
    }

    public Task<ListVideosResult> ListVideosAsync(long libraryId)
    {
        var url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{libraryId}/videos");

        return GetJsonAsync<ListVideosResult>(url);
    }

    public async Task CreateVideoCollectionAsync(CreateVideoCollection request)
    {
        string url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{request.LibraryId}/collections");

        await PostJsonAsync(url, request).ConfigureAwait(false);
    }

    public async Task<Video> ReEncodeVideoAsync(long libraryId, Guid videoId)
    {
        string url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{libraryId}/videos/{videoId}/reencode");

        return await PostAsync<Video>(url);
    }

    public Task<ListVideoCollectionResult> ListCollectionsAsync(long libraryId)
    {
        var url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{libraryId}/collections");

        return GetJsonAsync<ListVideoCollectionResult>(url);
    }

    public Task<VideoCollection> GetCollectionAsync(long libraryId, string collectionId)
    {
        var url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{libraryId}/collections/{collectionId}");

        return GetJsonAsync<VideoCollection>(url);
    }

    public async Task DeleteVideoAsync(long libraryId, long videoId) 
    {
        var url = string.Create(CultureInfo.InvariantCulture, $"{baseUri}/library/{libraryId}/videos/{videoId}");

        await DeleteAsync(url).ConfigureAwait(false);
    }

    private async Task<T> GetJsonAsync<T>(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        using var response = await SendMessageAsync(request).ConfigureAwait(false);

        var result = await response.Content.ReadFromJsonAsync<T>(JsonSerializerOptions.Default).ConfigureAwait(false);

        return result!;
    }

    private async Task<T> PostAsync<T>(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);

        using var response = await SendMessageAsync(request).ConfigureAwait(false);

        var result = await response.Content.ReadFromJsonAsync<T>(JsonSerializerOptions.Default).ConfigureAwait(false);

        return result!;
    }

    private async Task<TResult> PostJsonAsync<TRequest, TResult>(string url, TRequest data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url) {
            Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(data)) {
                Headers = { { "Content-Type", MediaTypeNames.Application.Json } }
            }
        };

        using var response = await SendMessageAsync(request).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            throw new Exception(responseText);
        }

        var result = await response.Content.ReadFromJsonAsync<TResult>(JsonSerializerOptions.Default).ConfigureAwait(false);

        return result!;
    }

    private async Task PostJsonAsync<T>(string url, T data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(data)) {
                Headers = { { "Content-Type", MediaTypeNames.Application.Json } }
            }
        };

        using var response = await SendMessageAsync(request).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            throw new Exception(responseText);
        }
    }

    private async Task DeleteAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url);

        await SendMessageAsync(request).ConfigureAwait(false);
    }

    private async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request)
    {
        request.Version = HttpVersion.Version20;

        request.Headers.Add("AccessKey", _accessKey);

        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            // {"Success":false,"Message":"Authentication failed","StatusCode":401}|Unauthorized

            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.StatusCode is HttpStatusCode.Unauthorized)
            {
                throw new BunnyException(HttpStatusCode.Unauthorized, responseText);
            }

            response.Dispose();

            throw new Exception($"{response.StatusCode} | {responseText}");
        }

        return response;
    }
}