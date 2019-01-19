﻿using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class VehicleData
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime Data { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TotalePercorso { get; set; }
    }
}