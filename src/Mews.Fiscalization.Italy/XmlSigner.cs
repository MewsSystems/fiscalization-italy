using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Mews.Fiscalization.Italy
{
    public static class XmlSigner
    {
        public static XmlDocument Sign(XmlDocument document, X509Certificate2 certificate)
        {
            var signedXml = new SignedXml(document)
            {
                SigningKey = certificate.PrivateKey,
                SignedInfo =
                {
                    SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256"
                }
            };

            var reference = new Reference
            {
                Uri = "",
                DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256"
            };

            var envTransform = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(envTransform);

            var xpathTransform = new XmlDsigXPathTransform();

            var transformBody = new XmlDocument();
            transformBody.LoadXml("<dsig:XPath xmlns:dsig='http://www.w3.org/2000/09/xmldsig#'>not(ancestor-or-self::dsig:Signature)</dsig:XPath>");

            xpathTransform.LoadInnerXml(transformBody.SelectNodes("/*[1]"));

            reference.AddTransform(xpathTransform);

            signedXml.AddReference(reference);

            var keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.KeyInfo = keyInfo;
            signedXml.ComputeSignature();

            var xmlSignature = signedXml.GetXml();


            var result = new XmlDocument();
            result.AppendChild(result.ImportNode(document.DocumentElement, true));

            // připojení podpisu na konec dokumentu XML
            result.DocumentElement.AppendChild(result.ImportNode(xmlSignature, true));

            return result;
        }

        public static X509Certificate2 GetCertificate(string subject)
        {
            // otevření uživatelského úložiště certifikátů
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.OpenExistingOnly);

            // načtení všech certifikátů z úložiště
            X509Certificate2Collection certificates = store.Certificates;

            // nalezení správného certifikátu
            foreach (X509Certificate2 c in certificates)
            {
                if (c.Subject.Equals(subject))
                {
                    return c;
                }
            }

            return null;
        }
    }
}
