using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    public class NotificaEsitoCommittenteType
    {
        public NotificaEsitoCommittenteType()
        {
            Versione = "1.0";
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string IdentificativoSdI { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RiferimentoFatturaType RiferimentoFattura { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public EsitoCommittenteType Esito { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Descrizione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MessageIdCommittente { get; set; }

        [XmlAttribute("versione")]
        public string Versione { get; set; }

        // TODO: Add signature.
    }
}