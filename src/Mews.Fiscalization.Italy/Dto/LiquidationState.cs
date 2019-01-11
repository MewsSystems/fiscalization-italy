using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum LiquidationState
    {
        /// <summary>
        /// In state of liquidation
        /// </summary>
        LS,
        /// <summary>
        /// Not in state of liquidation
        /// </summary>
        LN,
    }
}