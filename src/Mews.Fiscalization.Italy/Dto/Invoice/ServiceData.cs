using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ServiceData
    {
        [XmlElement("DettaglioLinee", Form = XmlSchemaForm.Unqualified)]
        public InvoiceLine[] InvoiceLines { get; set; }

        [XmlElement("DatiRiepilogo", Form = XmlSchemaForm.Unqualified)]
        public TaxRateSummary[] TaxSummary { get; set; }
    }
}