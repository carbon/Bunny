using System;

namespace BunnyCdn
{
    public sealed class AddCertificateRequest
    {
        public AddCertificateRequest(long pullZoneId, string hostname, byte[] certificate, byte[] certificateKey)
        {
            PullZoneId     = pullZoneId;
            Hostname       = hostname       ?? throw new ArgumentNullException(nameof(hostname));
            Certificate    = certificate    ?? throw new ArgumentNullException(nameof(certificate));
            CertificateKey = certificateKey ?? throw new ArgumentNullException(nameof(certificateKey));
        }

        public long PullZoneId { get; }

        public string Hostname { get; }

        // base64 encoded
        public byte[] Certificate { get; }

        // base64 encoded
        public byte[] CertificateKey { get; }
    }
}