namespace BunnyCdn;

public sealed class LoadFreeCertificateRequest
{
    public LoadFreeCertificateRequest(string hostname)
    {
        ArgumentNullException.ThrowIfNull(hostname);

        Hostname = hostname;
    }

    public string Hostname { get; }
}
