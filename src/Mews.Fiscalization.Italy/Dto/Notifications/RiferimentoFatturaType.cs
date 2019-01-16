using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    [XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0")]
    public class RiferimentoFatturaType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroFattura { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "nonNegativeInteger")]
        public string AnnoFattura { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "positiveInteger")]
        public string PosizioneFattura { get; set; }
    }
}