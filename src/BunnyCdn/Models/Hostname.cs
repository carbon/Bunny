#nullable disable

namespace BunnyCdn;

public sealed class Hostname
{
    public long Id { get; init; }

    public string Value { get; init; }

    public bool ForceSSL { get; init; }

    public bool IsSystemHostname { get; init; }

    public bool HasCertificate { get; init; }
}
