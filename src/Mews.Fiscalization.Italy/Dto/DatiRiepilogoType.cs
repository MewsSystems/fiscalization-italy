using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiRiepilogoType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public NaturaType Natura { get; set; }

        [XmlIgnore]
        public bool NaturaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal SpeseAccessorie { get; set; }

        [XmlIgnore]
        public bool SpeseAccessorieSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Arrotondamento { get; set; }

        [XmlIgnore]
        public bool ArrotondamentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImponibileImporto { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Imposta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public EsigibilitaIVAType EsigibilitaIVA { get; set; }

        [XmlIgnore]
        public bool EsigibilitaIVASpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoNormativo { get; set; }
    }
}