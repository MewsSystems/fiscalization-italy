using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    [XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0")]
    [XmlRoot("NotificaMancataConsegna", Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0", IsNullable = false)]
    public class FailedDeliveryNotification : SdiNotification
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataOraRicezione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RiferimentoArchivioType RiferimentoArchivio { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Descrizione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PecMessageId { get; set; }
    }
}