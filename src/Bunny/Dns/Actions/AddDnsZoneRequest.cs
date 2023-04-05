#nullable disable

namespace Bunny.Dns;

public sealed class AddDnsZoneRequest
{
    public long Id { get; set; }

    public required string Domain { get; set; }

    public DnsRecord[] Records { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime DateCreated { get; set; }

    public bool NameserversDetected { get; set; }

    public bool CustomNameserversEnabled { get; set; }

    public string Nameserver1 { get; set; }

    public string Nameserver2 { get; set; }

    public string SoaEmail { get; set; }

    public DateTime NameserversNextCheck { get; set; }

    public bool LoggingEnabled { get; set; }

    public int LogAnonymizationType { get; set; }

    public bool LoggingIPAnonymizationEnabled { get; set; }
}