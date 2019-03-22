﻿using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = ElectronicInvoice.Namespace)]
    public class TaxRateSummary
    {
        private decimal _vatRate;
        private decimal _complementaryExpenses;
        private decimal _rounding;
        private decimal _taxableAmount;
        private decimal _taxAmount;

        /// <summary>
        /// Required. Percentage.
        /// </summary>
        [XmlElement("AliquotaIVA", Form = XmlSchemaForm.Unqualified)]
        public decimal VatRate
        {
            get { return _vatRate; }
            set { _vatRate = DtoUtils.Normalize(value); }
        }

        /// <summary>
        /// Required if at least one of the invoice lines has Kind filled in. In those cases, this needs to match.
        /// </summary>
        [XmlElement("Natura", Form = XmlSchemaForm.Unqualified)]
        public TaxKind Kind { get; set; }

        [XmlIgnore]
        public bool KindSpecified { get; set; }

        [XmlElement("SpeseAccessorie", Form = XmlSchemaForm.Unqualified)]
        public decimal ComplementaryExpenses
        {
            get { return _complementaryExpenses; }
            set { _complementaryExpenses = DtoUtils.Normalize(value); }
        }

        [XmlIgnore]
        public bool ComplementaryExpensesSpecified { get; set; }

        [XmlElement("Arrotondamento", Form = XmlSchemaForm.Unqualified)]
        public decimal Rounding
        {
            get { return _rounding; }
            set { _rounding = DtoUtils.Normalize(value); }
        }

        [XmlIgnore]
        public bool RoundingSpecified { get; set; }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("ImponibileImporto", Form = XmlSchemaForm.Unqualified)]
        public decimal TaxableAmount
        {
            get { return _taxableAmount; }
            set { _taxableAmount = DtoUtils.Normalize(value); }
        }

        /// <summary>
        /// Required.
        /// </summary>
        [XmlElement("Imposta", Form = XmlSchemaForm.Unqualified)]
        public decimal TaxAmount
        {
            get { return _taxAmount; }
            set { _taxAmount = DtoUtils.Normalize(value); }
        }

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