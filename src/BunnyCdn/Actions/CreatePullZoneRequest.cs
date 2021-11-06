namespace BunnyCdn;

public sealed class CreatePullZoneRequest
{
    public CreatePullZoneRequest(string name, string originUrl, long? storageZoneId = null)
    {
        ArgumentNullException.ThrowIfNull(Name);
        ArgumentNullException.ThrowIfNull(originUrl);

        // a-z / 0-9
        if (name.Length < 3)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Must be at least 3 characters");
        }

        if (name.Length > 23)
        {
            throw new ArgumentOutOfRangeException(nameof(name), $"May not exceed 23 characters. Was {name.Length} characters.");
        }

        Name = name;
        OriginUrl = originUrl;
        StorageZoneId = storageZoneId;
    }

    // Max Length = 23
    // Min Length = 3

    // API Response | PullZone name must be between 5 and 23 characters

    public string Name { get; }

    public string OriginUrl { get; }

    public long? StorageZoneId { get; }
}
