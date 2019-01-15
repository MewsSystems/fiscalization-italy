using System.Collections.Generic;

namespace Mews.Fiscalization.Italy.Http
{
    public class HttpRequest
    {
        public Dictionary<string, string> Headers { get; set; }

        public string Content { get; set; }
    }
}
