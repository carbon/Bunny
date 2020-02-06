namespace BunnyCdn
{
    public sealed class SetCacheFileSlicingEnabledRequest
    {
        public SetCacheFileSlicingEnabledRequest(long pullZoneId, bool value)
        {
            Id = pullZoneId;
            Value = value;
        }

        public long Id { get; }

        public bool Value { get; }
    }
}