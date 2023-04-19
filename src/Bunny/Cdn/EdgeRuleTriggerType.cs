namespace Bunny.Cdn;

public enum EdgeRuleTriggerType
{
    Url            = 0,
    RequestHeader  = 1,
    ResponseHeader = 2,
    UrlExtension   = 3,
    CountryCode    = 4,
    RemoteIP       = 5,
    UrlQueryString = 6,
    RandomChance   = 7
}