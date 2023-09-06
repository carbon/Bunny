namespace Bunny.Cdn;

public sealed class SetZoneSecurityEnabledRequest(long pullZoneId, bool value)
{
    public long Id { get; } = pullZoneId;

    public bool Value { get; } = value;
}
