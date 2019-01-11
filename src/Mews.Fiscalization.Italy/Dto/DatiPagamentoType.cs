using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiPagamentoType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public CondizioniPagamentoType CondizioniPagamento { get; set; }

        [XmlElement("DettaglioPagamento", Form = XmlSchemaForm.Unqualified)]
        public DettaglioPagamentoType[] DettaglioPagamento { get; set; }
    }
}