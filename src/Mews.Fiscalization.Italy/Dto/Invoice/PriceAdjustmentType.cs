﻿using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum PriceAdjustmentType
    {
        /// <summary>
        /// Discount.
        /// </summary>
        SC,
        /// <summary>
        /// Extra charge.
        /// </summary>
        MG,
    }
}