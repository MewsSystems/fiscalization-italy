using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiBeniServiziType
    {
        [XmlElement("DettaglioLinee", Form = XmlSchemaForm.Unqualified)]
        public DettaglioLineeType[] DettaglioLinee { get; set; }

        [XmlElement("DatiRiepilogo", Form = XmlSchemaForm.Unqualified)]
        public DatiRiepilogoType[] DatiRiepilogo { get; set; }
    }
}