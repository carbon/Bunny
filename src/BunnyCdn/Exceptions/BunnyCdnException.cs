using System;
using System.Net;

namespace BunnyCdn.Exceptions
{
    public sealed class BunnyCdnException : Exception
    {
        public BunnyCdnException(HttpStatusCode statusCode, BunnyCdnError error)
            : base(error.Message)
        {
            StatusCode = statusCode;
            Error = error;
        }

        public BunnyCdnException(HttpStatusCode statusCode, string message)
            : base(message) {

            StatusCode = statusCode;
        }

        public BunnyCdnError? Error { get; }

        public HttpStatusCode StatusCode { get; }
    }
}