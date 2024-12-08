namespace Bunny.Cdn;

public sealed class CreatePullZoneRequest
{
    public CreatePullZoneRequest(string name, string originUrl, long? storageZoneId = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(originUrl);

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

    public string[]? AllowedReferrers { get; set; }

    public string[]? BlockedReferrers { get; set; }

    public bool? EnableQueryStringOrdering { get; set; }

    public bool? EnableAvifVary { get; set; }

    public bool? EnableWebpVary { get; set; }

    public bool? EnableCacheSlice { get; set; }

    public bool? IgnoreQueryStrings { get; set; }

    public bool? DisableCookies { get; set; }

    public string[]? BlockedCountries { get; set; }

    public bool? AddCanonicalHeader { get; set; }

    public bool? AddHostHeader { get; set; }

    public bool? LoggingIPAnonymizationEnabled { get; set; }

    public bool? EnableOriginShield { get; set; }

    public bool? EnableTLS1 { get; set; }

    public bool? EnableTLS1_1 { get; set; }

    public bool? LogForwardingEnabled { get; set; }

    public string? LogForwardingHostname { get; set; }

    public int? LogForwardingPort { get; set; }

    public string? LogForwardingToken { get; set; }

    public LogForwardingProtocol? LogForwardingProtocol { get; set; }

    public bool? WAFEnabled { get; set; }

    public LogAnonymizationType? LogAnonymizationType { get; set; }
}
