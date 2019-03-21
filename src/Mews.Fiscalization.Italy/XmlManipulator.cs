using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy
{
    public static class XmlManipulator
    {
        public static T Deserialize<T>(XmlElement xmlElement)
            where T : class, new()
        {
            using (var reader = new StringReader(xmlElement.OuterXml))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return xmlSerializer.Deserialize(reader) as T;
            }
        }

        public static XmlDocument Serialize<T>(T value)
            where T : class
        {
            var xmlDocument = new XmlDocument();
            var navigator = xmlDocument.CreateNavigator();
            using (var writer = navigator.AppendChild())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(writer, value);
            }
            return xmlDocument;
        }

        public static string SerializeToString<T>(T value)
        {
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value);
                return stream.ToString();
            }
        }
    }
}
