namespace BunnyCdn
{
    public sealed class SetZoneSecurityIncludeHashRemoteIPEnabledRequest
    {
        public SetZoneSecurityIncludeHashRemoteIPEnabledRequest(long pullZoneId, bool value)
        {
            Id = pullZoneId;
            Value = value;
        }

        public long Id { get; }

        public bool Value { get; }
    }
}