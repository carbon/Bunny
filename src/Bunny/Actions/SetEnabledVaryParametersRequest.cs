namespace Bunny.Cdn;

public sealed class SetEnabledVaryParametersRequest(
    long pullZoneId,
    bool queryStringVaryEnabled,
    bool requestHostnameVaryEnabled,
    bool userCountryCodeVaryEnabled,
    bool webpVaryEnabled)
{
    public long PullZoneId { get; } = pullZoneId;

    public bool QueryStringVaryEnabled { get; } = queryStringVaryEnabled;

    public bool RequestHostnameVaryEnabled { get; } = requestHostnameVaryEnabled;

    public bool UserCountryCodeVaryEnabled { get; } = userCountryCodeVaryEnabled;

    public bool WebpVaryEnabled { get; } = webpVaryEnabled;
}
