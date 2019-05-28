namespace BunnyCdn
{
    public enum EdgeRuleActionType : byte
    {
        BlockRequest = 4,
        ForceDownload = 7,
        ForceSSL = 0,
        ChangeOriginUrl = 2,
        OverrideCacheTime = 3,
        RedirectToUrl = 1,
        SetRequestHeader = 6,
        SetResponseHeader = 5,
        DisableTokenAuthentication = 8,
        EnableTokenAuthentication = 9
    }
}