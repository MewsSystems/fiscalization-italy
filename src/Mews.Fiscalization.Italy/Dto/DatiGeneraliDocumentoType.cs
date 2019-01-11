using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiGeneraliDocumentoType
    {
        [XmlElement("TipoDocumento", Form = XmlSchemaForm.Unqualified)]
        public DcoumentType DocumentType { get; set; }

        [XmlElement("Divisa", Form = XmlSchemaForm.Unqualified)]
        public string CurrencyCode { get; set; }

        [XmlElement("Data", Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime IssueDate { get; set; }

        [XmlElement("Numero", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string DocumentNumber { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiRitenutaType DatiRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiBolloType DatiBollo { get; set; }

        [XmlElement("DatiCassaPrevidenziale", Form = XmlSchemaForm.Unqualified)]
        public DatiCassaPrevidenzialeType[] DatiCassaPrevidenziale { get; set; }

        [XmlElement("ScontoMaggiorazione", Form = XmlSchemaForm.Unqualified)]
        public ScontoMaggiorazioneType[] ScontoMaggiorazione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoTotaleDocumento { get; set; }

        [XmlIgnore]
        public bool ImportoTotaleDocumentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Arrotondamento { get; set; }

        [XmlIgnore]
        public bool ArrotondamentoSpecified { get; set; }

        [XmlElement("Causale", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string[] Description { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Art73Type Art73 { get; set; }

        [XmlIgnore]
        public bool Art73Specified { get; set; }
    }
}