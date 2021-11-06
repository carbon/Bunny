namespace BunnyCdn;

public sealed class AddHostnameRequest
{
    public AddHostnameRequest(long pullZoneId, string hostname)
    {
        ArgumentNullException.ThrowIfNull(hostname);

        PullZoneId = pullZoneId;
        Hostname = hostname;
    }

    public long PullZoneId { get; }

    public string Hostname { get; }
}
