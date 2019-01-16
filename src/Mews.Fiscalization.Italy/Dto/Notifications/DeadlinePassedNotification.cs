using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    [XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0")]
    [XmlRoot("NotificaDecorrenzaTermini", Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0", IsNullable = false)]
    public class DeadlinePassedNotification : SdiNotification
    {
        public DeadlinePassedNotification()
        {
            IntermediarioConDupliceRuolo = "Si";
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RiferimentoFatturaType RiferimentoFattura { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Descrizione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PecMessageId { get; set; }

        [XmlAttribute]
        public string IntermediarioConDupliceRuolo { get; set; }
    }
}