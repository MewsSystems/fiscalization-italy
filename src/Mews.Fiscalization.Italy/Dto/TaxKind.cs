using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
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