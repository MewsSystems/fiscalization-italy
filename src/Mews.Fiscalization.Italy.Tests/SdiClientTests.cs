using System.Collections.Generic;
using System.Net;
using System.Text;
using Mews.Fiscalization.Italy.Communication;
using Mews.Fiscalization.Italy.Dto;
using Mews.Fiscalization.Italy.Http;
using NUnit.Framework;

namespace Mews.Fiscalization.Italy.Tests
{
    [TestFixture]
    public class SdiClientTests
    {
        [Test]
        public void TestResponse()
        {
            var cert = XmlSigner.GetCertificate("CN=Jan Novák");
            var sdiClient = new SdiClient(cert, async a => new HttpResponse(
                code: HttpStatusCode.OK,
                content: new HttpContent(
                    value: @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/""><s:Body xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><rispostaSdIRiceviFile xmlns=""http://www.fatturapa.gov.it/sdi/ws/trasmissione/v1.0/types""><IdentificativoSdI xmlns="""">e163afd5-7154-409d-b863-b5dd97428b61</IdentificativoSdI><DataOraRicezione xmlns="""">2019-01-15T17:41:38.3470614+01:00</DataOraRicezione></rispostaSdIRiceviFile></s:Body></s:Envelope>",
                    encoding: Encoding.UTF8,
                    mimeType: "text/xml"
                ), 
                headers: new Dictionary<string, string>()
            ));
            var response = sdiClient.SendAsync(new ElectronicInvoice()).Result;

            Assert.IsTrue(response.IsFirst);
        }
    }
}
