namespace BunnyCdn;

public sealed class SetZoneSecurityEnabledRequest
{
    public SetZoneSecurityEnabledRequest(long pullZoneId, bool value)
    {
        Id = pullZoneId;
        Value = value;
    }

    public long Id { get; }

    public bool Value { get; }
}
