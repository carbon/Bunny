#nullable disable

namespace BunnyCdn;

public sealed class IPGeoLocationInfo
{
    public string CountryCode { get; set; }

    public string Country { get; set; }

    public int ASN { get; set; }

    public string OrganizationName { get; set; }

    public string City { get; set; }
}
