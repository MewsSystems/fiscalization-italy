﻿using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class MainInvoice
    {
        [XmlElement("NumeroFatturaPrincipale", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string MainInvoiceNumber { get; set; }

        [XmlElement("DataFatturaPrincipale", Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime MainInvoiceDate { get; set; }
    }
}