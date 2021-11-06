namespace BunnyCdn;

public sealed class SetForceSslRequest
{
    public SetForceSslRequest(long pullZoneId, string hostname, bool forceSsl)
    {
        ArgumentNullException.ThrowIfNull(hostname);

        PullZoneId = pullZoneId;
        Hostname = hostname;
        ForceSSL = forceSsl;
    }

    public long PullZoneId { get; }

    public string Hostname { get; }

    public bool ForceSSL { get; }
}