using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiTrasmissioneType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdTrasmittente { get; set; }

        [XmlElement("ProgressivoInvio", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string SequentialNumber { get; set; }

        [XmlElement("FormatoTrasmissione", Form = XmlSchemaForm.Unqualified)]
        public FileSchemaVersion FileSchemaVersion { get; set; }

        [XmlElement("CodiceDestinatario", Form = XmlSchemaForm.Unqualified)]
        public string FinancialOfficeId { get; set; }

        [XmlElement("ContattiTrasmittente", Form = XmlSchemaForm.Unqualified)]
        public ContattiTrasmittenteType TransmitterContact { get; set; }
    }
}