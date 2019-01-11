using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class Address
    {
        public Address()
        {
            CountryCode = "IT";
        }

        [XmlElement("Indirizzo", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Street { get; set; }

        [XmlElement("NumeroCivico", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string HouseNumber { get; set; }

        [XmlElement("CAP", Form = XmlSchemaForm.Unqualified)]
        public string Zip { get; set; }

        [XmlElement("Comune", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string City { get; set; }

        [XmlElement("Provincia", Form = XmlSchemaForm.Unqualified)]
        public string ProvinceCode { get; set; }

        [XmlElement("Nazione", Form = XmlSchemaForm.Unqualified)]
        public string CountryCode { get; set; }
    }
}