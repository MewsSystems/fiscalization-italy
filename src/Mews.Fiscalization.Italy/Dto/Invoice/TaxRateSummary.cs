using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class TaxRateSummary
    {
        /// <summary>
        /// Required. Percentage.
        /// </summary>
        [XmlElement("AliquotaIVA", Form = XmlSchemaForm.Unqualified)]
        public decimal VatRate { get; set; }

        /// <summary>
        /// Required if at least one of the invoice lines has Kind filled in. In those cases, this needs to match.
        /// </summary>
        [XmlElement("Natura", Form = XmlSchemaForm.Unqualified)]
        public TaxKind Kind { get; set; }

        [XmlIgnore]
        public bool KindSpecified { get; set; }

        [XmlElement("SpeseAccessorie", Form = XmlSchemaForm.Unqualified)]
        public decimal ComplementaryExpenses { get; set; }

        [XmlIgnore]
        public bool ComplementaryExpensesSpecified { get; set; }

        [XmlElement("Arrotondamento", Form = XmlSchemaForm.Unqualified)]
        public decimal Rounding { get; set; }

        [XmlIgnore]
        public bool RoundingSpecified { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("ImponibileImporto", Form = XmlSchemaForm.Unqualified)]
        public decimal TaxableAmount { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("Imposta", Form = XmlSchemaForm.Unqualified)]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("EsigibilitaIVA", Form = XmlSchemaForm.Unqualified)]
        public VatDueDate VatDueDate { get; set; }

        [XmlIgnore]
        public bool VatDueDateSpecified { get; set; }

        /// <summary>
        /// Required if Kind is filled in and therefore in the case of transactions which are exempt from  VAT or in the case of a reversed charge.
        /// </summary>
        [XmlElement("RiferimentoNormativo", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NormativeReference { get; set; }
    }
}