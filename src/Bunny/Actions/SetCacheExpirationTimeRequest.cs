namespace Bunny.Cdn;

public sealed class SetCacheExpirationTimeRequest
{
    public SetCacheExpirationTimeRequest(long pullZoneId, int expirationTime)
    {
        if (expirationTime < 0)
        {
            throw new ArgumentException("Must be 0 or greater", nameof(expirationTime));
        }

        PullZoneId = pullZoneId;
        ExpirationTime = expirationTime;
    }

    public long PullZoneId { get; }

    public int ExpirationTime { get; }
}
