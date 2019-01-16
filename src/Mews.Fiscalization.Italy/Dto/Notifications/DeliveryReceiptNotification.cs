using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    [XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0")]
    [XmlRoot("RicevutaConsegna", Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0", IsNullable = false)]
    public class DeliveryReceiptNotification : SdiNotification
    {
        public DeliveryReceiptNotification()
        {
            IntermediarioConDupliceRuolo = "Si";
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataOraRicezione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataOraConsegna { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DestinatarioType Destinatario { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RiferimentoArchivioType RiferimentoArchivio { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PecMessageId { get; set; }

        [XmlAttribute]
        public string IntermediarioConDupliceRuolo { get; set; }
    }
}