using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum ModalitaPagamentoType
    {
        MP01,
        MP02,
        MP03,
        MP04,
        MP05,
        MP06,
        MP07,
        MP08,
        MP09,
        MP10,
        MP11,
        MP12,
        MP13,
        MP14,
        MP15,
        MP16,
        MP17,
        MP18,
        MP19,
        MP20,
        MP21,
    }
}