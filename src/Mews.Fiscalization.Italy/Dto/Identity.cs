using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class Identity
    {
        /// <summary>
        /// Companies use Denominazione, natural persons use Nome and Cognome.
        /// </summary>
        [XmlElement("Cognome", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlElement("Denominazione", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlElement("Nome", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlChoiceIdentifier("ItemsElementName")]
        public string[] Items { get; set; }

        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType[] ItemsElementName { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Titolo { get; set; }

        /// <summary>
        /// Optional: Economic Operator Registration and Identification.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodEORI { get; set; }
    }
}