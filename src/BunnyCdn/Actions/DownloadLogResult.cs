using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BunnyCdn
{
    public sealed class DownloadLogResult : IDisposable
    {
        private readonly HttpResponseMessage response;

        internal DownloadLogResult(HttpResponseMessage response)
        {
            this.response = response;
        }

        public async Task<Stream> OpenAsync()
        {
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            response.Dispose();
        }
    }
}