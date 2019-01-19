using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class PaymentData
    {
        [XmlElement("CondizioniPagamento", Form = XmlSchemaForm.Unqualified)]
        public PaymentTerms PaymentTerms { get; set; }

        [XmlElement("DettaglioPagamento", Form = XmlSchemaForm.Unqualified)]
        public PaymentDetail[] PaymentDetails { get; set; }
    }
}