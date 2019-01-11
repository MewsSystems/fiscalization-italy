using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ScontoMaggiorazioneType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TipoScontoMaggiorazioneType Tipo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Percentuale { get; set; }

        [XmlIgnore]
        public bool PercentualeSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Importo { get; set; }

        [XmlIgnore]
        public bool ImportoSpecified { get; set; }
    }
}