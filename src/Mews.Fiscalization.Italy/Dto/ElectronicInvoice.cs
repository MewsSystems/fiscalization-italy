using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1"), XmlRoot("FatturaElettronica", Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1", IsNullable = false)]
    public class ElectronicInvoice
    {
        [XmlElement("FatturaElettronicaHeader", Form = XmlSchemaForm.Unqualified)]
        public ElectronicInvoiceHeader Header { get; set; }

        [XmlElement("FatturaElettronicaBody", Form = XmlSchemaForm.Unqualified)]
        public ElectronicInvoiceBody[] Body { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }

        [XmlAttribute]
        public VersioneSchemaType versione { get; set; }
    }
}
