#nullable disable

namespace BunnyCdn
{
    public sealed class Hostname
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public bool ForceSSL { get; set; }

        public bool IsSystemHostname { get; set; }

        public bool HasCertificate { get; set; }
    }
}