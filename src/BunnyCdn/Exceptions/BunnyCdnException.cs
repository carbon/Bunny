using System;
using System.Net;

namespace BunnyCdn.Exceptions
{
    public sealed class BunnyCdnException : Exception
    {
        public BunnyCdnException(HttpStatusCode statusCode, string message)
            : base(message) {

            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }

}