using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class TransmissionData
    {
        public TransmissionData()
        {
            TransmissionFormat = TransmissionFormat.SDI11;
        }

        [XmlElement("IdTrasmittente", Form = XmlSchemaForm.Unqualified)]
        public SenderId TransmitterId { get; set; }

        /// <summary>
        /// Sender identification.
        /// </summary>
        [XmlElement("ProgressivoInvio", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string SequentialNumber { get; set; }

        [XmlElement("FormatoTrasmissione", Form = XmlSchemaForm.Unqualified)]
        public TransmissionFormat TransmissionFormat { get; set; }

        [XmlElement("CodiceDestinatario", Form = XmlSchemaForm.Unqualified)]
        public string FinancialOfficeId { get; set; }

        [XmlElement("ContattiTrasmittente", Form = XmlSchemaForm.Unqualified)]
        public TransmitterContact TransmitterContact { get; set; }
    }
}