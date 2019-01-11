using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum DcoumentType
    {
        TD01,
        TD02,
        TD03,
        TD04,
        TD05,
        TD06,
    }
}