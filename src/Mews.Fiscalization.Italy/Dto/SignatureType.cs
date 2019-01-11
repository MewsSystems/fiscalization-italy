using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignatureType
    {
        public SignedInfoType SignedInfo { get; set; }

        public SignatureValueType SignatureValue { get; set; }

        public KeyInfoType KeyInfo { get; set; }

        [XmlElement("Object")]
        public ObjectType[] Object { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }
}