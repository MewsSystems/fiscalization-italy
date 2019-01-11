using System.Collections.Generic;
using System.Net;

namespace Mews.Fiscalization.Italy.Http
{
    public class HttpResponseContent
    {
        public HttpStatusCode Code { get; set; }

        public string Value { get; set; }

        public Dictionary<string, string> Headers { get; set; }
    }
}