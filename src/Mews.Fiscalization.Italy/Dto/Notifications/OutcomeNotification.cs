using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    [XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0")]
    [XmlRoot("NotificaEsito", Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0", IsNullable = false)]
    public class OutcomeNotification : SdiNotification
    {
        public OutcomeNotification()
        {
            IntermediarioConDupliceRuolo = "Si";
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public NotificaEsitoCommittenteType EsitoCommittente { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PecMessageId { get; set; }

        [XmlAttribute]
        public string IntermediarioConDupliceRuolo { get; set; }
    }
}