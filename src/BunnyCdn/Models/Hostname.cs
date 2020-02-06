#nullable disable

using System.Runtime.Serialization;

namespace BunnyCdn
{
    public sealed class Hostname
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public bool ForceSSL { get; set; }

        public bool IsSystemHostname { get; set; }

        [DataMember(Name = "HasCertificate")]
        public bool HasCertificate { get; set; }
    }
}