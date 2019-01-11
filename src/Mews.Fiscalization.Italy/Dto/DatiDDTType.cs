using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiDDTType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroDDT { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataDDT { get; set; }

        [XmlElement("RiferimentoNumeroLinea", Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string[] RiferimentoNumeroLinea { get; set; }
    }
}