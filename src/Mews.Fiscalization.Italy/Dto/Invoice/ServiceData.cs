using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class ServiceData
    {
        [XmlElement("DettaglioLinee", Form = XmlSchemaForm.Unqualified)]
        public InvoiceLine[] InvoiceLines { get; set; }

        [XmlElement("DatiRiepilogo", Form = XmlSchemaForm.Unqualified)]
        public TaxRateSummary[] TaxSummary { get; set; }
    }
}