using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = ElectronicInvoice.Namespace)]
    public class InvoiceLine
    {
        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("NumeroLinea", Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string LineNumber { get; set; }

        /// <summary>
        /// Required if the line  referred to regards a discount, bonus, reduction or extra charge.
        /// </summary>
        [XmlElement("TipoCessionePrestazione", Form = XmlSchemaForm.Unqualified)]
        public ServiceType ServiceType { get; set; }

        [XmlIgnore]
        public bool ServiceTypeSpecified { get; set; }

        /// <summary>
        /// Reuired if the inte ntion is to record the fact that the article described on the detail line is included among those encoded according to the known code types(e.g.  CPV, EAN, TARIC, etc.)
        /// </summary>
        [XmlElement("CodiceArticolo", Form = XmlSchemaForm.Unqualified)]
        public ArticleCode[] ArticleCode { get; set; }

        [XmlElement("Descrizione", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Description { get; set; }

        [XmlElement("Quantita", Form = XmlSchemaForm.Unqualified)]
        public decimal UnitCount { get; set; }

        [XmlIgnore]
        public bool UnitCountSpecified { get; set; }

        /// <summary>
        /// Required if UnitCount is filled in.
        /// </summary>
        [XmlElement("UnitaMisura", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string MeasurementUnit { get; set; }

        /// <summary>
        /// Required if the detail  line refers  to a  service which  is provided over a certain length of time and which is invoiced according to distinct periods.
        /// </summary>
        [XmlElement("DataInizioPeriodo", Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime PeriodStartingDate { get; set; }

        [XmlIgnore]
        public bool PeriodStartingDateSpecified { get; set; }

        /// <summary>
        /// Required if the detail  line refers  to a  service which  is provided over a certain length of time and which is invoiced according to distinct periods.
        /// </summary>
        [XmlElement("DataFinePeriodo", Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime PeriodClosingDate { get; set; }

        [XmlIgnore]
        public bool PeriodClosingDateSpecified { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("PrezzoUnitario", Form = XmlSchemaForm.Unqualified)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Required if there are any.
        /// </summary>
        [XmlElement("ScontoMaggiorazione", Form = XmlSchemaForm.Unqualified)]
        public PriceAdjustment[] PriceAdjustments { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("PrezzoTotale", Form = XmlSchemaForm.Unqualified)]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Percentage of VAT rate.
        /// </summary>
        [XmlElement("AliquotaIVA", Form = XmlSchemaForm.Unqualified)]
        public decimal VatRate { get; set; }

        [XmlElement("Ritenuta", Form = XmlSchemaForm.Unqualified)]
        public RitenutaType WithholdingTax { get; set; }

        [XmlIgnore]
        public bool WithholdingTaxSpecified { get; set; }

        /// <summary>
        /// Required if the transaction is not included in the "taxable" transactions or in the case of a reverse charge.
        /// </summary>
        [XmlElement("Natura", Form = XmlSchemaForm.Unqualified)]
        public TaxKind Kind { get; set; }

        [XmlIgnore]
        public bool KindSpecified { get; set; }

        /// <summary>
        /// Recommended.
        /// </summary>
        [XmlElement("RiferimentoAmministrazione", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string AdministrationReference { get; set; }

        /// <summary>
        /// Required  if requested by addressee.
        /// </summary>
        [XmlElement("AltriDatiGestionali", Form = XmlSchemaForm.Unqualified)]
        public OtherInvoiceLineData[] OtherData { get; set; }
    }
}