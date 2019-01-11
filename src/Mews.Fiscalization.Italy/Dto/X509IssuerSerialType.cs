using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509IssuerSerialType
    {
        public string X509IssuerName { get; set; }

        [XmlElement(DataType = "integer")]
        public string X509SerialNumber { get; set; }
    }
}