#nullable disable

namespace BunnyCdn;

public sealed class CreateVideoLibraryRequest
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string[] ReplicationRegions { get; set; }
}