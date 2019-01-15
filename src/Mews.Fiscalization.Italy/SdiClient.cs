using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Mews.Fiscalization.Italy.Communication;
using Mews.Fiscalization.Italy.Dto;
using Mews.Fiscalization.Italy.Dto.Receive;
using Mews.Fiscalization.Italy.Http;

namespace Mews.Fiscalization.Italy
{
    public class SdiClient
    {
        public const string Url = "";

        public SdiClient(X509Certificate2 signatureCertificate, Func<HttpRequest, Task<HttpResponse>> httpClient)
        {
            SignatureCertificate = signatureCertificate;
            SoapClient = new SoapClient(new Uri(Url), httpClient);
        }

        private X509Certificate2 SignatureCertificate { get; }

        private SoapClient SoapClient { get; }

        public async Task<SdiResponse> SendAsync(ElectronicInvoice invoice)
        {
            var invoiceXmlDoc = XmlManipulator.Serialize(invoice);
            var signedInvoiceXmlDoc = XmlSigner.Sign(invoiceXmlDoc, SignatureCertificate);

            var signedInvoiceXml = signedInvoiceXmlDoc.OuterXml;
            var signedInvoiceBytes = Encoding.UTF8.GetBytes(signedInvoiceXml);

            var signedInvoiceFileName = $"{Guid.NewGuid()}.xml";

            var messageBody = new ReceiveFile
            {
                Content = signedInvoiceBytes,
                FileName = signedInvoiceFileName
            };

            var response = await SoapClient.SendAsync<ReceiveFile, ReceiveFileResponse>(messageBody, operation: "http://www.fatturapa.it/SdIRiceviFile/RiceviFile");
            return new SdiResponse(new SdiFileInfo(
                receivedUtc: response.ReceivedOn,
                sdiIdentifier: response.SdiIdentification
            ));
        }
    }
}
