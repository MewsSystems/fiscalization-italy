using System.Collections.Generic;

namespace Mews.Fiscalization.Italy.Http
{
    public class HttpRequest
    {
        public HttpRequest(string url, HttpMethod method, HttpContent content, Dictionary<string, string> headers)
        {
            Url = url;
            Method = method;
            Headers = headers;
            Content = content;
        }

        public string Url { get; }

        public HttpMethod Method { get; }

        public Dictionary<string, string> Headers { get; }

        public HttpContent Content { get; }
    }
}
