using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = ElectronicInvoice.Namespace)]
    public class SenderId
    {
        [XmlElement("IdPaese", Form = XmlSchemaForm.Unqualified)]
        public string CountryCode { get; set; }

        [XmlElement("IdCodice", Form = XmlSchemaForm.Unqualified)]
        public string TaxCode { get; set; }
    }
}