using System.Net;

namespace Bunny.Exceptions;

public sealed class BunnyException : Exception
{
    public BunnyException(HttpStatusCode statusCode, BunnyError error)
        : base(error.Message)
    {
        StatusCode = statusCode;
        Error = error;
    }

    public BunnyException(HttpStatusCode statusCode, string message)
        : base(message)
    {

        StatusCode = statusCode;
    }

    public BunnyError? Error { get; }

    public HttpStatusCode StatusCode { get; }
}