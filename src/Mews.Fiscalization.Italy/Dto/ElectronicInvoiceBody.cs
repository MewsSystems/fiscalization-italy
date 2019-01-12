using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ElectronicInvoiceBody
    {
        [XmlElement("DatiGenerali", Form = XmlSchemaForm.Unqualified)]
        public GeneralData GeneralData { get; set; }

        [XmlElement("DatiBeniServizi", Form = XmlSchemaForm.Unqualified)]
        public ServiceData ServiceData { get; set; }

        /// <summary>
        /// Required if the documented is related to sale of new vehicles.
        /// </summary>
        [XmlElement("DatiVeicoli", Form = XmlSchemaForm.Unqualified)]
        public VehicleData VehicleData { get; set; }

        /// <summary>
        /// Required if there are any payment conditions/deadlines.
        /// </summary>
        [XmlElement("DatiPagamento", Form = XmlSchemaForm.Unqualified)]
        public PaymentData[] PaymentData { get; set; }

        [XmlElement("Allegati", Form = XmlSchemaForm.Unqualified)]
        public InvoiceAttachment[] Attachments { get; set; }
    }
}