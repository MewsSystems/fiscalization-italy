using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Mews.Fiscalization.Italy.Dto;
using Mews.Fiscalization.Italy.Http;
using Mews.Sdi;

namespace Mews.Fiscalization.Italy.Communication
{
    public class SdiClient
    {
        public SdiClient(X509Certificate2 signatureCertificate, Func<HttpRequest, HttpResponse> httpClient)
        {
            SignatureCertificate = signatureCertificate;
            HttpClient = httpClient;
        }

        private X509Certificate2 SignatureCertificate { get; }

        private Func<HttpRequest, HttpResponse> HttpClient { get; }

        public async Task<SdiResponse> SendAsync(ElectronicInvoice invoice)
        {
            var document = XmlManipulator.Serialize(invoice);
            // var signedDocument = XmlSigner.Sign(document, SignatureCertificate);.

            return new SdiResponse(new SdiFileInfo(DateTime.UtcNow, 123));
        }
    }
}
