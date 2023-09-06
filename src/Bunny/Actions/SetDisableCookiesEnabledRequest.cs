namespace Bunny.Cdn;

public sealed class SetDisableCookiesEnabledRequest(long pullZoneId, bool value)
{
    public long Id { get; } = pullZoneId;

    public bool Value { get; } = value;
}
