namespace BunnyCdn
{
    public enum EdgeRuleTriggerType : byte
    {
        RequestUrl = 0,
        RequestHeader = 1,
        ResponseHeader = 2,
        CountryCode = 4,
        RemoteIP = 5,
        FileExtension = 3
    }
}