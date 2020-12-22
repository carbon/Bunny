#nullable disable

namespace BunnyCdn.Exceptions
{
    public sealed class BunnyCdnError
    {
        public string ErrorKey { get; set; }

        public string Field { get; set; }

        public string Message { get; set; }
    }
}

// {"ErrorKey":"pullzone.hostname_already_registered","Field":"Hostname","Message":"The hostname is already registered."}
