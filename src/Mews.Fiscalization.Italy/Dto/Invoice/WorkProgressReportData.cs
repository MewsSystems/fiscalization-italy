using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class WorkProgressReportData
    {
        [XmlElement("RiferimentoFase", Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string PhaseReference { get; set; }
    }
}