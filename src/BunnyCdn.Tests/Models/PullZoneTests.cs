using System.Text.Json;

namespace BunnyCdn.Models.Tests;

public class PullZoneTests
{
    [Fact]
    public void CanSerialize()
    {
        var zone = new PullZone {
            Id = 11,
            Type = 0,
            AddHostHeader = true,
            BlockedCountries = new[] { "AU" }
        };

        Assert.Equal("""
            {
              "Id": 11,
              "AddHostHeader": true,
              "Type": 0,
              "BlockedCountries": [
                "AU"
              ]
            }
            """, JsonSerializer.Serialize(zone, JSO.Default));
    }

    [Fact]
    public void CanDeserialize()
    {
        var zones = JsonSerializer.Deserialize<PullZone[]>(
            """
            [
              { 
                "Id":1,
                "Name":"a",
                "OriginUrl":"https://origin",
                "Enabled":true,
                "Hostnames":[
                    {
                        "Id":101560,
                        "Value":"a.b-cdn.net",
                        "ForceSSL":false,
                        "IsSystemHostname":true,      
                        "HasCertificate":true
                    }
                ],
                "StorageZoneId":0,
                "AllowedReferrers":[],
                "BlockedReferrers":[],
                "BlockedIps":[],  
                "EnableGeoZoneUS":true,
                "EnableGeoZoneEU":true,
                "EnableGeoZoneASIA":true,
                "EnableGeoZoneSA":true,
                "EnableGeoZoneAF":true,
                "ZoneSecurityEnabled":false,
                "ZoneSecurityKey":"sc",
                "ZoneSecurityIncludeHashRemoteIP":false,
                "IgnoreQueryStrings":true,
                "MonthlyBandwidthLimit":0,
                "MonthlyBandwidthUsed":380371,
                "MonthlyCharges":0.00000380371,
                "AddHostHeader":false,
                "Type":0,
                "CustomNginxConfig":"",
                "AccessControlOriginHeaderExtensions":["eot","ttf","woff","woff2","css"],
                "EnableAccessControlOriginHeader":true,
                "DisableCookies":true,
                "BudgetRedirectedCountries":[],
                "BlockedCountries":[],
                "EnableOriginShield":false,
                "CacheControlMaxAgeOverride":180,
                "BurstSize":0,"RequestLimit":0,
                "BlockRootPathAccess":false,
                "CacheQuality":75,
                "LimitRatePerSecond":0.0,
                "LimitRateAfter":0.0,
                "ConnectionLimitPerIPCount":0,
                "PriceOverride":0.0,
                "AddCanonicalHeader":false,
                "EnableLogging":false,
                "IgnoreVaryHeader":true,
                "EnableCacheSlice":false,
                "EdgeRules":[],
                "EnableWebPVary":false,
                "EnableCountryCodeVary":false,
                "EnableMobileVary":false,
                "EnableHostnameVary":false,
                "CnameDomain":"b-cdn.net"
            }]
            """);

        var z0 = zones[0];

        Assert.Equal(1, z0.Id);
        Assert.Equal("a", z0.Name);
        Assert.Equal("https://origin", z0.OriginUrl);
        Assert.Equal("b-cdn.net", z0.CnameDomain);

        Assert.Equal(101560, z0.Hostnames[0].Id);
        Assert.Equal("a.b-cdn.net", z0.Hostnames[0].Value);

        Assert.Equal("sc", z0.ZoneSecurityKey);

        Assert.True(z0.Enabled);
        Assert.False(z0.EnableCountryCodeVary);

        Assert.Equal(5, z0.AccessControlOriginHeaderExtensions.Length);

        Assert.Equal(Array.Empty<string>(), zones[0].AllowedReferrers);
        Assert.Equal(Array.Empty<string>(), zones[0].BlockedReferrers);
    }

    [Fact]
    public void Serialize2()
    {
        var zone = new PullZone {
            Id = 11,
            Type = 0,
            BlockedIps = new[] {
                "1.1.1.1"
            },
            AccessControlOriginHeaderExtensions = new[] { "eot" },
            EnableAccessControlOriginHeader = true,
            EnableWebPVary = true,
            EnableAvifVary = true,
            EnableLogging = true,
            DisableCookies = true,
            EnableGeoZoneAF = true,
            EnableGeoZoneASIA = true,
            EnableCacheSlice = true,
            IgnoreQueryStrings = false
        };

        Assert.Equal("""
            {
              "Id": 11,
              "BlockedIps": [
                "1.1.1.1"
              ],
              "EnableGeoZoneASIA": true,
              "EnableGeoZoneAF": true,
              "IgnoreQueryStrings": false,
              "Type": 0,
              "AccessControlOriginHeaderExtensions": [
                "eot"
              ],
              "EnableAccessControlOriginHeader": true,
              "DisableCookies": true,
              "EnableLogging": true,
              "EnableCacheSlice": true,
              "EnableWebPVary": true,
              "EnableAvifVary": true
            }
            """, JsonSerializer.Serialize(zone, JSO.Default));
    }
}