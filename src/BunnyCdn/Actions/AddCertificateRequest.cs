namespace BunnyCdn;

public sealed class AddCertificateRequest
{
    public AddCertificateRequest(long pullZoneId, string hostname, byte[] certificate, byte[] certificateKey)
    {
        ArgumentNullException.ThrowIfNull(hostname);
        ArgumentNullException.ThrowIfNull(certificate);
        ArgumentNullException.ThrowIfNull(certificate);

        PullZoneId = pullZoneId;
        Hostname = hostname;
        Certificate = certificate;
        CertificateKey = certificateKey;
    }

    public long PullZoneId { get; }

    public string Hostname { get; }

    // base64 encoded
    public byte[] Certificate { get; }

    // base64 encoded
    public byte[] CertificateKey { get; }
}