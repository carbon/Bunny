#nullable disable

namespace Bunny.Cdn;

public sealed class Region
{
    public string ContinentCode { get; set; }

    public string CountryCode { get; set; }

    public long Id { get; set; }
    
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string Name { get; set; }

    public decimal PricePerGigabyte { get; set; }

    public string RegionCode { get; set; }
}
