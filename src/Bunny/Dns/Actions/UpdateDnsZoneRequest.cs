namespace Bunny.Dns;

public sealed class UpdateDnsZoneRequest
{
    public long Id { get; set; }

    public bool CustomNameserversEnabled { get; set; }

    public string? Nameserver1 { get; set; }

    public string? Nameserver2 { get; set; }

    public string? SoaEmail { get; set; }

    public bool LoggingEnabled { get; set; }

    public int LogAnonymizationType { get; set; }

    public bool LoggingIPAnonymizationEnabled { get; set; }
}