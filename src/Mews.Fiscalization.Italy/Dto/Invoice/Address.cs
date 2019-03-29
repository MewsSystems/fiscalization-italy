﻿using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = ElectronicInvoice.Namespace)]
    public class Address
    {
        private string zip;
        private string _street;
        private string _city;

        public Address()
        {
            CountryCode = "IT";
        }

        [XmlElement("Indirizzo", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Street
        {
            get { return _street; }
            set { _street = value.NormalizeString(); }
        }

        [XmlElement("NumeroCivico", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string HouseNumber { get; set; }

        [XmlElement("CAP", Form = XmlSchemaForm.Unqualified)]
        public string Zip
        {
            get { return zip; }
            set { zip = value.NormalizeZip(); }
        }

        [XmlElement("Comune", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string City
        {
            get { return _city; }
            set { _city = value.NormalizeString(); }
        }

        [XmlElement("Provincia", Form = XmlSchemaForm.Unqualified)]
        public string ProvinceCode { get; set; }

        [XmlElement("Nazione", Form = XmlSchemaForm.Unqualified)]
        public string CountryCode { get; set; }
    }
}