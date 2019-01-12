using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum ServiceType
    {
        /// <summary>
        /// Discount
        /// </summary>
        SC,
        /// <summary>
        /// Bonus
        /// </summary>
        PR,
        /// <summary>
        /// Refund
        /// </summary>
        AB,
        /// <summary>
        /// Extra charge
        /// </summary>
        AC,
    }
}