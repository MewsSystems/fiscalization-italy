using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum InvoiceLineKind
    {
        N1,
        N2,
        N3,
        N4,
        N5,
        N6,
    }
}