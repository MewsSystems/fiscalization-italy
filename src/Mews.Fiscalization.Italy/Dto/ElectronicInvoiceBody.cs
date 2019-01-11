using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ElectronicInvoiceBody
    {
        [XmlElement("DatiGenerali", Form = XmlSchemaForm.Unqualified)]
        public GeneralData GeneralData { get; set; }

        [XmlElement("DatiBeniServizi", Form = XmlSchemaForm.Unqualified)]
        public DatiBeniServiziType DatiBeniServizi { get; set; }

        [XmlElement("DatiVeicoli", Form = XmlSchemaForm.Unqualified)]
        public DatiVeicoliType DatiVeicoli { get; set; }

        [XmlElement("DatiPagamento", Form = XmlSchemaForm.Unqualified)]
        public DatiPagamentoType[] DatiPagamento { get; set; }

        [XmlElement("Allegati", Form = XmlSchemaForm.Unqualified)]
        public AllegatiType[] Allegati { get; set; }
    }
}