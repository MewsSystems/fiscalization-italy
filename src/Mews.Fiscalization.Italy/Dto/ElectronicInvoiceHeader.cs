using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ElectronicInvoiceHeader
    {
        [XmlElement("DatiTrasmissione", Form = XmlSchemaForm.Unqualified)]
        public DatiTrasmissioneType DatiTrasmissione { get; set; }

        [XmlElement("CedentePrestatore", Form = XmlSchemaForm.Unqualified)]
        public Provider Provider { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RappresentanteFiscaleType RappresentanteFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public CessionarioCommittenteType CessionarioCommittente { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TerzoIntermediarioSoggettoEmittenteType TerzoIntermediarioOSoggettoEmittente { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SoggettoEmittenteType SoggettoEmittente { get; set; }

        [XmlIgnore]
        public bool SoggettoEmittenteSpecified { get; set; }
    }
}