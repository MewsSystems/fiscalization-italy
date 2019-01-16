﻿using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    [XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0")]
    public class DestinatarioType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Codice { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Descrizione { get; set; }
    }
}