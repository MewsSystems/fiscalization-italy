using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public enum DocumentType
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