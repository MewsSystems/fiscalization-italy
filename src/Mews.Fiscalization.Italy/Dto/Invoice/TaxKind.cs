using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public enum TaxKind
    {
        [XmlEnum("N1")]
        ExcludingArticle15,
        [XmlEnum("N2")]
        NotSubject,
        [XmlEnum("N3")]
        NotTaxable,
        [XmlEnum("N4")]
        Exempt,
        [XmlEnum("N5")]
        MarginRegime,
        [XmlEnum("N6")]
        ReverseCharge
    }
}