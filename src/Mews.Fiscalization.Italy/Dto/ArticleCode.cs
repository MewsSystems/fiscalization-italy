using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ArticleCode
    {
        [XmlElement("CodiceTipo", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TypeCode { get; set; }

        [XmlElement("CodiceValore", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string ValueCode { get; set; }
    }
}