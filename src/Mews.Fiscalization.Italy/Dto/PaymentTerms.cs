using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum PaymentTerms
    {
        /// <summary>
        /// Installments
        /// </summary>
        TP01,
        /// <summary>
        /// Full payment in a lump sum 
        /// </summary>
        TP02,
        /// <summary>
        /// In advance
        /// </summary>
        TP03,
    }
}