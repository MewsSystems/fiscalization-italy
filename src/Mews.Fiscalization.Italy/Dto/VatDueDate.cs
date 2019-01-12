using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum VatDueDate
    {
        /// <summary>
        /// Deferred
        /// </summary>
        D,
        /// <summary>
        /// Immediately
        /// </summary>
        I,
        /// <summary>
        /// Split payment
        /// </summary>
        S,
    }
}