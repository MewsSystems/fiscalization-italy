using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class TransportDocumentData
    {
        [XmlElement("NumeroDDT", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TransportDocumentNumber { get; set; }

        [XmlElement("DataDDT", Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime TransportDocumentDate { get; set; }

        [XmlElement("RiferimentoNumeroLinea", Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string[] LineNumber { get; set; }
    }
}