using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SignatureProperties", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignaturePropertiesType
    {
        [XmlElement("SignatureProperty")]
        public SignaturePropertyType[] SignatureProperty { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }
}