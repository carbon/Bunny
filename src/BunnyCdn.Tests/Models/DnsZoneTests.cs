using System.Text.Json;

namespace BunnyCdn.Tests;

public class DnsZoneTests
{
    [Fact]
    public void CanDeserialize()
    {
        var zone = JsonSerializer.Deserialize<AddDnsZoneRequest>(
            """
            {
              "Id": 1,
              "Domain": "test.com",
              "Records": [
                {
                  "Id": 0,
                  "Type": 0,
                  "Ttl": 0,
                  "Value": "string",
                  "Name": "string",
                  "Weight": 0,
                  "Priority": 0,
                  "Port": 0,
                  "Flags": 0,
                  "Tag": "string",
                  "Accelerated": true,
                  "AcceleratedPullZoneId": 11,
                  "LinkName": "string",
                  "IPGeoLocationInfo": {
                    "CountryCode": "string",
                    "Country": "string",
                    "ASN": 0,
                    "OrganizationName": "string",
                    "City": "string"
                  },
                  "MonitorStatus": 0,
                  "MonitorType": 0,
                  "GeolocationLatitude": 0,
                  "GeolocationLongitude": 0,
                  "EnviromentalVariables": [
                    {
                      "Name": "string",
                      "Value": "string"
                    }
                  ],
                  "LatencyZone": "string",
                  "SmartRoutingType": 0,
                  "Disabled": true
                }
              ],
              "DateModified": "2022-08-26T20:49:43.128Z",
              "DateCreated": "2022-08-26T20:49:43.128Z",
              "NameserversDetected": true,
              "CustomNameserversEnabled": true,
              "Nameserver1": "string",
              "Nameserver2": "string",
              "SoaEmail": "admin@test.com",
              "NameserversNextCheck": "2022-08-26T20:49:43.128Z",
              "LoggingEnabled": true,
              "LoggingIPAnonymizationEnabled": true,
              "LogAnonymizationType": 0
            }
            """);


        Assert.Equal(1, zone.Id);
        Assert.Equal("test.com", zone.Domain);

        Assert.Single(zone.Records);

        var record = zone.Records[0];

        Assert.Equal(0, record.IPGeoLocationInfo.ASN);
        Assert.Equal(11, record.AcceleratedPullZoneId);
        Assert.True(record.Accelerated);
        Assert.True(record.Disabled);

        Assert.Equal(new DateTime(2022, 08, 26, 20, 49, 43, 128, DateTimeKind.Utc), zone.DateModified);

        Assert.Equal("string", zone.Nameserver1);
        Assert.Equal("string", zone.Nameserver2);

        Assert.Equal("admin@test.com", zone.SoaEmail);
        Assert.True(zone.LoggingEnabled);
        Assert.True(zone.LoggingIPAnonymizationEnabled);
    }
}
