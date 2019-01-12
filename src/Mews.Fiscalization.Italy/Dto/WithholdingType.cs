using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum WithholdingType
    {
        /// <summary>
        /// Natural person.
        /// </summary>
        RT01,
        /// <summary>
        /// Legal person (company).
        /// </summary>
        RT02,
    }
}