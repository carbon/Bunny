#nullable disable

namespace BunnyCdn;

public sealed class DnsZone
{
    public long Id { get; set; }

    public string Domain { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime DateCreated { get; set; }

    public bool NameserversDetected { get; set; }

    public bool CustomNameserversEnabled { get; set; }

    public string Nameserver1 { get; set; }

    public string Nameserver2 { get; set; }

    public string SoaEmail { get; set; }

    public DateTime NameserversNextCheck { get; set; }

    public bool LoggingEnabled { get; set; }
}