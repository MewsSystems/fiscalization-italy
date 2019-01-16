using System.Collections.Generic;
using System.Net;

namespace Mews.Fiscalization.Italy.Http
{
    public sealed class HttpResponse
    {
        public HttpResponse(HttpStatusCode code, HttpContent content, List<HttpHeader> headers)
        {
            Code = code;
            Content = content;
            Headers = headers;
        }

        public HttpStatusCode Code { get; }

        public HttpContent Content { get; }

        public List<HttpHeader> Headers { get; }
    }
}