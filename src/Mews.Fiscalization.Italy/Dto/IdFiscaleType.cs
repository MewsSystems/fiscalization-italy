using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class IdFiscaleType
    {
        [XmlElement("IdPaese", Form = XmlSchemaForm.Unqualified)]
        public string CountryCode { get; set; }

        [XmlElement("IdCodice", Form = XmlSchemaForm.Unqualified)]
        public string VatNumber { get; set; }
    }
}