namespace Bunny.Cdn;

public sealed class SetTlsSupportRequest(
    long pullZoneId,
    bool enableTls1,
    bool enableTls1_1)
{
    public long PullZoneId { get; } = pullZoneId;

    public bool EnableTLS1 { get; } = enableTls1;

    public bool EnableTLS1_1 { get; } = enableTls1_1;
}
