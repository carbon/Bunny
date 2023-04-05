namespace Bunny.Cdn;

public sealed class SetDisableCookiesEnabledRequest
{
    public SetDisableCookiesEnabledRequest(long pullZoneId, bool value)
    {
        Id = pullZoneId;
        Value = value;
    }

    public long Id { get; }

    public bool Value { get; }
}
