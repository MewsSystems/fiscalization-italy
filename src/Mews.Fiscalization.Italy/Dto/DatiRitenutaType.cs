using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiRitenutaType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TipoRitenutaType TipoRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public CausalePagamentoType CausalePagamento { get; set; }
    }
}