﻿using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using BunnyCdn.Exceptions;

namespace BunnyCdn
{
    public sealed class BunnyVideoClient
    {
        private const string baseUri = "https://video.bunnycdn.com/";

        private readonly HttpClient httpClient = new () {
            Timeout = TimeSpan.FromMinutes(10) 
        };

        private readonly string _accessKey;

        public BunnyVideoClient(string accessKey)
        {
            _accessKey = accessKey ?? throw new ArgumentNullException(nameof(accessKey));
        }

        public async Task<Video> CreateVideoAsync(CreateVideoRequest request) 
        {
            string url = baseUri + $"library/{request.LibraryId}/videos";

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(request)) {
                    Headers = { { "Content-Type", "application/json" } }
                }
            };

            using var response = await SendMessageAsync(requestMessage).ConfigureAwait(false);

            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);


            using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var jsonResult = await JsonSerializer.DeserializeAsync<Video>(responseStream).ConfigureAwait(false);

            return jsonResult!;
        }

        public async Task FetchVideoAsync(FetchVideoRequest request) 
        {
            string url = baseUri + $"library/{request.LibraryId}/videos/{request.VideoId}/fetch";

            // {"success":true,"message":"OK","statusCode":200}

            await PostJsonAsync(url, request).ConfigureAwait(false);
        }

        public async Task<Video> GetVideoAsync(long libraryId, Guid videoId)
        {
            string url = baseUri + $"library/{libraryId}/videos/{videoId}";

            return await GetJsonAsync<Video>(url).ConfigureAwait(false);
        }

        public async Task CreateVideoCollectionAsync(CreateVideoCollection request)
        {
            string url = baseUri + $"library/{request.LibraryId}/collections";

            await PostJsonAsync(url, request).ConfigureAwait(false);
        }

        public Task<ListVideoCollectionResult> ListCollectionsAsync(long libraryId)
        {
            var url = baseUri + "library/" + libraryId + "/collections";

            return GetJsonAsync<ListVideoCollectionResult>(url);
        }

        public Task<VideoCollection> GetCollectionAsync(long libraryId, string collectionId)
        {
            var url = baseUri + "library/" + libraryId + "/collections/" + collectionId;

            return GetJsonAsync<VideoCollection>(url);
        }

        public async Task DeleteVideoAsync(long libraryId, long videoId) 
        {
            var url = baseUri + "library/" + libraryId + "/videos/" + videoId;

            await DeleteAsync(url).ConfigureAwait(false);
        }

        private async Task<T> GetJsonAsync<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            using var response = await SendMessageAsync(request).ConfigureAwait(false);

            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            throw new Exception(responseText);

            using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var jsonResult = await JsonSerializer.DeserializeAsync<T>(responseStream).ConfigureAwait(false);

            return jsonResult!;
        }

        private async Task PostJsonAsync<T>(string url, T data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(data)) {
                    Headers = { { "Content-Type", "application/json" } }
                }
            };

            using var response = await SendMessageAsync(request).ConfigureAwait(false);

            var responseText = await response.Content.ReadAsStringAsync();

            throw new Exception(responseText);
        }

        private async Task DeleteAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            using var response = await SendMessageAsync(request).ConfigureAwait(false);

            string responseText = await response.Content.ReadAsStringAsync();

            throw new Exception(responseText);
        }

        private async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request)
        {
            request.Version = HttpVersion.Version20;

            request.Headers.Add("AccessKey", _accessKey);

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                // {"Success":false,"Message":"Authentication failed","StatusCode":401}|Unauthorized

                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.StatusCode is HttpStatusCode.Unauthorized)
                {
                    throw new BunnyCdnException(HttpStatusCode.Unauthorized, responseText);
                }

                response.Dispose();

                throw new Exception(response.StatusCode + "|" + responseText);
            }

            return response;
        }
    }
}