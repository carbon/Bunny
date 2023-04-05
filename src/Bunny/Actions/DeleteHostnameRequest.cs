namespace Bunny.Cdn;

public sealed class DeleteHostnameRequest
{
    public DeleteHostnameRequest(long pullZoneId, string hostname)
    {
        ArgumentNullException.ThrowIfNull(hostname);
            
        PullZoneId = pullZoneId;
        Hostname = hostname;
    }

    public long PullZoneId { get; }

    public string Hostname { get; }
}