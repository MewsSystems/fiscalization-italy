using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class AnagraficaType
    {
        [XmlElement("Cognome", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlElement("Denominazione", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlElement("Nome", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlChoiceIdentifier("ItemsElementName")]
        public string[] Items { get; set; }

        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType[] ItemsElementName { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Titolo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodEORI { get; set; }
    }
}