using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiSALType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string RiferimentoFase { get; set; }
    }
}