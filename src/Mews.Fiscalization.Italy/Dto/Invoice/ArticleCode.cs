using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class ArticleCode
    {
        [XmlElement("CodiceTipo", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TypeCode { get; set; }

        [XmlElement("CodiceValore", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string ValueCode { get; set; }
    }
}