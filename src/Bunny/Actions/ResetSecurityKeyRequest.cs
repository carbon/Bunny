namespace Bunny.Cdn;

public sealed class ResetSecurityKeyRequest(long pullZoneId)
{
    public long Id { get; } = pullZoneId;
}