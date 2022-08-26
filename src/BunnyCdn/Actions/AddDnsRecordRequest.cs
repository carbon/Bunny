#nullable disable

namespace BunnyCdn;

public sealed class AddDnsRecordRequest
{
    public /*required*/ long ZoneId { get; set; }

    public long Id { get; set; }

    public int Type { get; set; }

    public int Ttl { get; set; }

    public string Value { get; set; }

    public string Name { get; set; }

    public int Weight { get; set; }

    public int Priority { get; set; }

    public int Flags { get; set; }

    public string Tag { get; set; }

    public int Port { get; set; }

    public long PullZoneId { get; set; }
   
    public long ScriptId { get; set; }

    public bool Accelerated { get; set; }

    public int MonitorType { get; set; }

    public double GeolocationLatitude { get; set; }

    public double GeolocationLongitude { get; set; }

    public int SmartRoutingType { get; set; }

    public bool Disabled { get; set; }
}
