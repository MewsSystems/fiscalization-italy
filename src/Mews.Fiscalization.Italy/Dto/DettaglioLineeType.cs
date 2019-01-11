using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DettaglioLineeType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string NumeroLinea { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TipoCessionePrestazioneType TipoCessionePrestazione { get; set; }

        [XmlIgnore]
        public bool TipoCessionePrestazioneSpecified { get; set; }

        [XmlElement("CodiceArticolo", Form = XmlSchemaForm.Unqualified)]
        public CodiceArticoloType[] CodiceArticolo { get; set; }

        [XmlElement("Descrizione", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Description { get; set; }

        [XmlElement("Quantita", Form = XmlSchemaForm.Unqualified)]
        public decimal UnitCount { get; set; }

        [XmlIgnore]
        public bool UnitCountSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string UnitaMisura { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataInizioPeriodo { get; set; }

        [XmlIgnore]
        public bool DataInizioPeriodoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataFinePeriodo { get; set; }

        [XmlIgnore]
        public bool DataFinePeriodoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PrezzoUnitario { get; set; }

        [XmlElement("ScontoMaggiorazione", Form = XmlSchemaForm.Unqualified)]
        public ScontoMaggiorazioneType[] ScontoMaggiorazione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PrezzoTotale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RitenutaType Ritenuta { get; set; }

        [XmlIgnore]
        public bool RitenutaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public NaturaType Natura { get; set; }

        [XmlIgnore]
        public bool NaturaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoAmministrazione { get; set; }

        [XmlElement("AltriDatiGestionali", Form = XmlSchemaForm.Unqualified)]
        public AltriDatiGestionaliType[] AltriDatiGestionali { get; set; }
    }
}