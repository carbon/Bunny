namespace Bunny.Cdn;

public sealed class SetEnabledVaryParametersRequest
{
    public SetEnabledVaryParametersRequest(
        long pullZoneId,
        bool queryStringVaryEnabled,
        bool requestHostnameVaryEnabled,
        bool userCountryCodeVaryEnabled,
        bool webpVaryEnabled)
    {
        PullZoneId = pullZoneId;
        QueryStringVaryEnabled = queryStringVaryEnabled;
        RequestHostnameVaryEnabled = requestHostnameVaryEnabled;
        UserCountryCodeVaryEnabled = userCountryCodeVaryEnabled;
        WebpVaryEnabled = webpVaryEnabled;
    }

    public long PullZoneId { get; }

    public bool QueryStringVaryEnabled { get; }

    public bool RequestHostnameVaryEnabled { get; }

    public bool UserCountryCodeVaryEnabled { get; }

    public bool WebpVaryEnabled { get; }
}
