using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class PriceAdjustment
    {
        [XmlElement("Tipo", Form = XmlSchemaForm.Unqualified)]
        public PriceAdjustmentType Type { get; set; }

        [XmlElement("Percentuale", Form = XmlSchemaForm.Unqualified)]
        public decimal Percentage { get; set; }

        [XmlIgnore]
        public bool PercentageSpecified { get; set; }

        [XmlElement("Importo", Form = XmlSchemaForm.Unqualified)]
        public decimal Amount { get; set; }

        [XmlIgnore]
        public bool AmountSpecified { get; set; }
    }
}