using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum PaymentTerms
    {
        [XmlEnum("TP01")]
        Installments,
        [XmlEnum("TP02")]
        LumpSum,
        [XmlEnum("TP03")]
        InAdvance,
    }
}