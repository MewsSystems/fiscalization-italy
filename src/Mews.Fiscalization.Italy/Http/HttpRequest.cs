using System;
using System.Collections.Generic;

namespace Mews.Fiscalization.Italy.Http
{
    public class HttpRequest
    {
        public HttpRequest(Uri uri, HttpMethod method, HttpContent content, Dictionary<string, string> headers)
        {
            Uri = uri;
            Method = method;
            Headers = headers;
            Content = content;
        }

        public Uri Uri { get; }

        public HttpMethod Method { get; }

        public Dictionary<string, string> Headers { get; }

        public HttpContent Content { get; }
    }
}
