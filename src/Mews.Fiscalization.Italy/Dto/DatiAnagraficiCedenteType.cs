using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiAnagraficiCedenteType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AnagraficaType Anagrafica { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string AlboProfessionale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ProvinciaAlbo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroIscrizioneAlbo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataIscrizioneAlbo { get; set; }

        [XmlIgnore]
        public bool DataIscrizioneAlboSpecified { get; set; }

        [XmlElement("RegimeFiscale", Form = XmlSchemaForm.Unqualified)]
        public FiscalRegime FiscalRegime { get; set; }
    }
}