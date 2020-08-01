namespace BunnyCdn
{
    public sealed class SetTlsSupportRequest
    {
        public SetTlsSupportRequest(long pullZoneId, bool enableTls1, bool enableTls1_1)
        {
            PullZoneId = pullZoneId;
            EnableTLS1 = enableTls1;
            EnableTLS1_1 = enableTls1_1;
        }

        public long PullZoneId { get; }

        public bool EnableTLS1 { get; }

        public bool EnableTLS1_1 { get; }
    }
}