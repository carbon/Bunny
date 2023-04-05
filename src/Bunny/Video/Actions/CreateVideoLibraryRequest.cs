#nullable disable

namespace Bunny.Cdn;

public sealed class CreateVideoLibraryRequest
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string[] ReplicationRegions { get; set; }
}