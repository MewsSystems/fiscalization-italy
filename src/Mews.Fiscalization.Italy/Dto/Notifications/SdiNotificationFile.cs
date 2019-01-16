using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Notifications
{
    public class SdiNotificationFile
    {
        [XmlElement("IdentificativoSdI", Form = XmlSchemaForm.Unqualified)]
        public string SdiIdentification { get; set; }

        [XmlElement("NomeFile", Form = XmlSchemaForm.Unqualified)]
        public string FileName { get; set; }

        [XmlElement("File", Form = XmlSchemaForm.Unqualified)]
        public byte[] FileContent { get; set; }
    }
}
