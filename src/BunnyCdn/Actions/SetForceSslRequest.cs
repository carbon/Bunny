using System;

namespace BunnyCdn
{
    public sealed class SetForceSslRequest
    {
        public SetForceSslRequest(long pullZoneId, string hostname, bool forceSsl)
        {
            PullZoneId = pullZoneId;
            Hostname = hostname ?? throw new ArgumentNullException(nameof(hostname));
            ForceSSL = forceSsl;
        }

        public long PullZoneId { get; }

        public string Hostname { get; }

        public bool ForceSSL { get; }
    }
}