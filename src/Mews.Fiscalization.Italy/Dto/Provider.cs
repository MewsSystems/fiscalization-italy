using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class Provider
    {
        [XmlElement("DatiAnagrafici", Form = XmlSchemaForm.Unqualified)]
        public DatiAnagraficiCedenteType IdentificationData { get; set; }

        [XmlElement("Sede", Form = XmlSchemaForm.Unqualified)]
        public Address Address { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Address StabileOrganizzazione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IscrizioneREAType IscrizioneREA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ContattiType Contatti { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoAmministrazione { get; set; }
    }
}