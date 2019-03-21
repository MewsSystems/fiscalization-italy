using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public enum WithholdingType
    {
        [XmlEnum("RT01")]
        NaturalPerson,
        [XmlEnum("RT02")]
        LegalPerson,
    }
}