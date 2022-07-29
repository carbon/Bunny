using System.IO;
using System.Net.Http;

namespace BunnyCdn;

public sealed class DownloadLogResult : IDisposable
{
    private readonly HttpResponseMessage _response;

    internal DownloadLogResult(HttpResponseMessage response)
    {
        _response = response;
    }

    public async Task<Stream> OpenAsync()
    {
        return await _response.Content.ReadAsStreamAsync().ConfigureAwait(false);
    }

    public void Dispose()
    {
        _response.Dispose();
    }
}