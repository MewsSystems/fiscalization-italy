using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class TransmitterContact
    {
        [XmlElement("Telefono", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Phone { get; set; }

        [XmlElement("Email", Form = XmlSchemaForm.Unqualified)]
        public string Email { get; set; }
    }
}