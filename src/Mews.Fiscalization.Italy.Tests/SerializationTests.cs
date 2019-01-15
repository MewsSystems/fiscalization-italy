using Mews.Fiscalization.Italy.Dto;
using NUnit.Framework;

namespace Mews.Fiscalization.Italy.Tests
{
    [TestFixture]
    public class SerializationTests
    {
        [Test]
        public void Test()
        {
            var invoice = new ElectronicInvoice
            {
                Body = new[]
                {
                    new ElectronicInvoiceBody
                    {
                        GeneralData = new GeneralData
                        {
                            GeneralDocumentData = new GeneralDocumentData
                            {
                                CurrencyCode = "EUR"
                            }
                        }
                    }
                }
            };

            var xml = XmlManipulator.Serialize(invoice).OuterXml;
        }
    }
}
