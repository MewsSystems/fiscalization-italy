using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
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