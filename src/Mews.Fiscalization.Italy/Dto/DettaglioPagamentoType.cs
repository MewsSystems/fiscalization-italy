using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DettaglioPagamentoType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Beneficiario { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ModalitaPagamentoType ModalitaPagamento { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataRiferimentoTerminiPagamento { get; set; }

        [XmlIgnore]
        public bool DataRiferimentoTerminiPagamentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string GiorniTerminiPagamento { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataScadenzaPagamento { get; set; }

        [XmlIgnore]
        public bool DataScadenzaPagamentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoPagamento { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodUfficioPostale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CognomeQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NomeQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CFQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TitoloQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string IstitutoFinanziario { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string IBAN { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ABI { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CAB { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BIC { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ScontoPagamentoAnticipato { get; set; }

        [XmlIgnore]
        public bool ScontoPagamentoAnticipatoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataLimitePagamentoAnticipato { get; set; }

        [XmlIgnore]
        public bool DataLimitePagamentoAnticipatoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PenalitaPagamentiRitardati { get; set; }

        [XmlIgnore]
        public bool PenalitaPagamentiRitardatiSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataDecorrenzaPenale { get; set; }

        [XmlIgnore]
        public bool DataDecorrenzaPenaleSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodicePagamento { get; set; }
    }
}