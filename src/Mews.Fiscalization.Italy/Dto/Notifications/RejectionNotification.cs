using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    [XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0")]
    [XmlRoot("NotificaScarto", Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0", IsNullable = false)]
    public class RejectionNotification : SdiNotification
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataOraRicezione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RiferimentoArchivioType RiferimentoArchivio { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Errore", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ErroreType[] ListaErrori { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PecMessageId { get; set; }
    }
}