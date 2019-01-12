﻿using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class WithholdingData
    {
        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("TipoRitenuta", Form = XmlSchemaForm.Unqualified)]
        public WithholdingType WithholdingType { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("ImportoRitenuta", Form = XmlSchemaForm.Unqualified)]
        public decimal WithholdingAmount { get; set; }

        /// <summary>
        /// Required. Contains percentage withheld. (20 % is represented as 20.0)
        /// </summary>
        [XmlElement("AliquotaRitenuta", Form = XmlSchemaForm.Unqualified)]
        public decimal WithHoldingRate { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("CausalePagamento", Form = XmlSchemaForm.Unqualified)]
        public PaymentReason PaymentReason { get; set; }
    }
}