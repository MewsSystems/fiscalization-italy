using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class TransmissionData
    {
        public TransmissionData()
        {
            TransmissionFormat = TransmissionFormat.FPA12;
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