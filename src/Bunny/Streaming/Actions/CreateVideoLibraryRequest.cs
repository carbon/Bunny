#nullable disable

namespace Bunny.Streaming;

public sealed class CreateVideoLibraryRequest
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string[] ReplicationRegions { get; set; }
}