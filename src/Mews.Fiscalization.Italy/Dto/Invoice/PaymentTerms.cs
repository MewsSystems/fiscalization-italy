using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
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