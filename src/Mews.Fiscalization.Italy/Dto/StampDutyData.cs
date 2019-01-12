using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class StampDutyData
    {
        public StampDutyData()
        {
            StampDutyPaid = StampDutyPaid.SI;
        }

        [XmlElement("BolloVirtuale", Form = XmlSchemaForm.Unqualified)]
        public StampDutyPaid StampDutyPaid { get; set; }

        [XmlElement("ImportoBollo", Form = XmlSchemaForm.Unqualified)]
        public decimal AmountPaid { get; set; }
    }
}