using System;

namespace BunnyCdn
{
    public sealed class LoadFreeCertificateRequest
    {
        public LoadFreeCertificateRequest(string hostname)
        {
            Hostname = hostname ?? throw new ArgumentNullException(nameof(hostname));
        }

        public string Hostname { get; }
    }
}