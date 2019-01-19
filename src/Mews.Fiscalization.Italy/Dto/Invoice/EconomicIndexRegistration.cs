using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class EconomicIndexRegistration
    {
        [XmlElement("Ufficio", Form = XmlSchemaForm.Unqualified)]
        public string OfficeId { get; set; }

        [XmlElement("NumeroREA", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string IndexNumber { get; set; }

        [XmlElement("CapitaleSociale", Form = XmlSchemaForm.Unqualified)]
        public decimal ShareCapital { get; set; }

        [XmlIgnore]
        public bool ShareCapitalSpecified { get; set; }

        [XmlElement("SocioUnico", Form = XmlSchemaForm.Unqualified)]
        public ShareholderDistribution ShareholderDistribution { get; set; }

        [XmlIgnore]
        public bool ShareholderDistributionSpecified { get; set; }

        [XmlElement("StatoLiquidazione", Form = XmlSchemaForm.Unqualified)]
        public LiquidationState LiquidationState { get; set; }
    }
}