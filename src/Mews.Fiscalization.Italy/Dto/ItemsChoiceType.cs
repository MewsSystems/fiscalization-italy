using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        [XmlEnum(":Cognome")]
        Cognome,
        [XmlEnum(":Denominazione")]
        Denominazione,
        [XmlEnum(":Nome")]
        Nome,
    }
}