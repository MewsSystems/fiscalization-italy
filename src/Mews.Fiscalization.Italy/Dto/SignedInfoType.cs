using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignedInfoType
    {
        public CanonicalizationMethodType CanonicalizationMethod { get; set; }

        public SignatureMethodType SignatureMethod { get; set; }

        [XmlElement("Reference")]
        public ReferenceType[] Reference { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }
}