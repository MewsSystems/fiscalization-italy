using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Mews.Fiscalization.Italy.Dto.XmlSignature;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1"), XmlRoot("FatturaElettronica", Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1", IsNullable = false)]
    public class ElectronicInvoice
    {
        [XmlElement("FatturaElettronicaHeader", Form = XmlSchemaForm.Unqualified)]
        public ElectronicInvoiceHeader Header { get; set; }

        [XmlElement("FatturaElettronicaBody", Form = XmlSchemaForm.Unqualified)]
        public ElectronicInvoiceBody[] Body { get; set; }

        [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

        [XmlAttribute("versione")]
        public VersioneSchemaType Version { get; set; }
    }
}
