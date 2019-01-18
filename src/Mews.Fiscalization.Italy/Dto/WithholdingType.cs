using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum WithholdingType
    {
        [XmlEnum("RT01")]
        NaturalPerson,
        [XmlEnum("RT02")]
        LegalPerson,
    }
}