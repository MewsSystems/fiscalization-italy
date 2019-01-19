using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class Identity
    {
        [XmlElement("Nome", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string FirstName { get; set; }

        [XmlElement("Cognome", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string LastName { get; set; }

        [XmlElement("Denominazione", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CompanyName { get; set; }


        /// <summary>
        /// Optional.
        /// </summary>
        [XmlElement("Titolo", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Title { get; set; }

        /// <summary>
        /// Optional: Economic Operator Registration and Identification.
        /// </summary>
        [XmlElement("CodEORI", Form = XmlSchemaForm.Unqualified)]
        public string EoriCode { get; set; }
    }
}