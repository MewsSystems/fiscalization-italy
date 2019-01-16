using System;
using System.Collections.Generic;

namespace Mews.Fiscalization.Italy.Http
{
    public sealed class HttpRequest
    {
        public HttpRequest(Uri uri, HttpMethod method, HttpContent content, List<HttpHeader> headers)
        {
            Uri = uri;
            Method = method;
            Headers = headers;
            Content = content;
        }

        public Uri Uri { get; }

        public HttpMethod Method { get; }

        public List<HttpHeader> Headers { get; }

        public HttpContent Content { get; }
    }
}
