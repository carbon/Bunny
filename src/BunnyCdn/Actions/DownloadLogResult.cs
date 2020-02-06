using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BunnyCdn
{
    public sealed class DownloadLogResult : IDisposable
    {
        private readonly HttpResponseMessage response;

        public DownloadLogResult(HttpResponseMessage response)
        {
            this.response = response;
        }

        public async Task<Stream> OpenAsync()
        {
            return await this.response.Content.ReadAsStreamAsync();

        }

        public void Dispose()
        {
            response.Dispose();
        }
    }
}