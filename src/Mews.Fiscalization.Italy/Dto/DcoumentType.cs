﻿using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum DcoumentType
    {
        [XmlEnum("TD01")]
        Invoice,
        [XmlEnum("TD02")]
        InvoiceDeposit,
        [XmlEnum("TD03")]
        DepositFee,
        [XmlEnum("TD04")]
        CreditNote,
        [XmlEnum("TD05")]
        DebitNote,
        [XmlEnum("TD06")]
        Fee
    }
}