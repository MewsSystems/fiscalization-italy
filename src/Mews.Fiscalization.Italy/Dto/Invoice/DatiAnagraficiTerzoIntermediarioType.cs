﻿using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class DatiAnagraficiTerzoIntermediarioType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SenderId IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Identity Anagrafica { get; set; }
    }
}