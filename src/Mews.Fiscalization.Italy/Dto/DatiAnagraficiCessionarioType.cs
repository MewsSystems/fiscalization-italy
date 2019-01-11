using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiAnagraficiCessionarioType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SenderId IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Identity Anagrafica { get; set; }
    }
}