using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class IscrizioneREAType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Ufficio { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroREA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal CapitaleSociale { get; set; }

        [XmlIgnore]
        public bool CapitaleSocialeSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SocioUnicoType SocioUnico { get; set; }

        [XmlIgnore]
        public bool SocioUnicoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public StatoLiquidazioneType StatoLiquidazione { get; set; }
    }
}