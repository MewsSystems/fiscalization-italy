using FuncSharp;

namespace Mews.Fiscalization.Italy.Http
{
    public class HttpResponse : Coproduct2<HttpResponseContent, HttpError>
    {
        public HttpResponse(HttpResponseContent content)
            : base(content)
        {
        }

        public HttpResponse(HttpError error)
            : base(error)
        {
        }
    }
}