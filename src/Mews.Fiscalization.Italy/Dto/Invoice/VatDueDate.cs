using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum VatDueDate
    {
        [XmlEnum("D")]
        Deferred,
        [XmlEnum("I")]
        Immediate,
        [XmlEnum("S")]
        SplitPayment,
    }
}