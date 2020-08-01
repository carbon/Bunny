#nullable disable

namespace BunnyCdn
{
    public sealed class PullZone
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string OriginUrl { get; set; }

        public bool? Enabled { get; set; }

        public Hostname[] Hostnames { get; set; }

        public long? StorageZoneId { get; set; }

        public string[] AllowedReferrers { get; set; }

        public string[] BlockedReferrers { get; set; }

        public string[] BlockedIps { get; set; }

        public bool? EnableGeoZoneUS { get; set; }

        public bool? EnableGeoZoneEU { get; set; }

        // Asia
        public bool? EnableGeoZoneASIA { get; set; }

        // South America
        public bool? EnableGeoZoneSA { get; set; }

        // Africa
        public bool? EnableGeoZoneAF { get; set; }

        public bool? ZoneSecurityEnabled { get; set; }

        public string ZoneSecurityKey { get; set; }

        public bool? ZoneSecurityIncludeHashRemoteIP { get; set; }

        public bool? IgnoreQueryStrings { get; set; }

        public long? MonthlyBandwidthLimit { get; set; }

        public long? MonthlyBandwidthUsed { get; set; } // in bytes

        public decimal? MonthlyCharges { get; set; }

        public bool? AddHostHeader { get; set; }

        public string CustomNgnixConfig { get; set; }

        public int? Type { get; set; }

        public string[] AccessControlOriginHeaderExtensions { get; set; }

        public bool? EnableAccessControlOriginHeader { get; set; }

        public bool? DisableCookies { get; set; }

        public string[] BudgetRedirectedCountries { get; set; }

        public string[] BlockedCountries { get; set; }

        public bool? EnableOriginShield { get; set; }

        public int? CacheControlMaxAgeOverride { get; set; }

        public long? BurstSize { get; set; }

        public long? RequestLimit { get; set; }

        public bool? BlockRootPathAccess { get; set; }

        public double? LimitRatePerSecond { get; set; }

        public double? LimitRateAfter { get; set; }

        public long? ConnectionLimitPerIPCount { get; set; }

        public bool? AddCanonicalHeader { get; set; }

        public bool? EnableLogging { get; set; }

        public bool? IgnoreVaryHeader { get; set; }

        // Enables Range Requests
        public bool? EnableCacheSlice { get; set; }

        public bool? EnableWebPVary { get; set; }

        public bool? EnableCountryCodeVary { get; set; }

        public bool? EnableMobileVary { get; set; }

        public bool? EnableHostnameVary { get; set; }

        public string CnameDomain { get; set; }

        public bool? EnableTLS1 { get; set; }

        public bool? EnableTLS1_1 { get; set; }
    }
}