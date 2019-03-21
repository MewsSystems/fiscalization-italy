using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class MainInvoice
    {
        [XmlElement("NumeroFatturaPrincipale", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string MainInvoiceNumber { get; set; }

        [XmlElement("DataFatturaPrincipale", Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime MainInvoiceDate { get; set; }
    }
}