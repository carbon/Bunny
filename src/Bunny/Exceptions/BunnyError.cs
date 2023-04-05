#nullable disable

namespace Bunny.Exceptions;

public sealed class BunnyError
{
    public string ErrorKey { get; set; }

    public string Field { get; set; }

    public string Message { get; set; }
}

// {"ErrorKey":"pullzone.hostname_already_registered","Field":"Hostname","Message":"The hostname is already registered."}
