using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class CodiceArticoloType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodiceTipo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodiceValore { get; set; }
    }
}