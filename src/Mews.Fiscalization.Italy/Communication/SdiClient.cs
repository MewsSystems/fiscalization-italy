using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Mews.Fiscalization.Italy.Dto;
using Mews.Fiscalization.Italy.Dto.Receive;
using Mews.Fiscalization.Italy.Http;
using Mews.Sdi;

namespace Mews.Fiscalization.Italy.Communication
{
    public class SdiClient
    {
        public const string Url = "";

        public SdiClient(X509Certificate2 signatureCertificate, Func<HttpRequest, Task<HttpResponse>> httpClient)
        {
            SignatureCertificate = signatureCertificate;
            HttpClient = httpClient;
        }

        private X509Certificate2 SignatureCertificate { get; }

        private Func<HttpRequest, Task<HttpResponse>> HttpClient { get; }

        public async Task<SdiResponse> SendAsync(ElectronicInvoice invoice)
        {
            var document = XmlManipulator.Serialize(invoice);
            var signedDocument = XmlSigner.Sign(document, SignatureCertificate);
            var message = signedDocument.OuterXml;

            var httpRequest = new HttpRequest(
                url: Url,
                method: HttpMethod.Post,
                content: new HttpContent(
                    value: message,
                    encoding: Encoding.UTF8,
                    mimeType: "text/xml"
               ),
                headers: new Dictionary<string, string>
                {
                    ["SOAPAction"] = "http://www.fatturapa.it/SdIRiceviFile/RiceviFile"
                }
            );

            var httpResponse = await HttpClient(httpRequest).ConfigureAwait(continueOnCapturedContext: false);
            var soapBody = GetSoapBody(httpResponse);
            var response = XmlManipulator.Deserialize<ReceiveFileResponse>(soapBody);

            return new SdiResponse(new SdiFileInfo(
                receivedUtc: response.DataOraRicezione,
                sdiIdentifier: response.IdentificativoSdI
            ));
        }

        private XmlElement GetSoapBody(HttpResponse httpResponse)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(httpResponse.Content.Value);

            var soapMessage = SoapMessage.FromSoapXml(xmlDocument);
            if (!soapMessage.VerifySignature())
            {
                throw new SecurityException("The SOAP message signature is not valid.");
            }
            return soapMessage.Body.XmlElement.FirstChild as XmlElement;
        }
    }
}
