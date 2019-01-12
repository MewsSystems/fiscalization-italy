using Mews.Fiscalization.Italy.Dto;
using Mews.Sdi;
using NUnit.Framework;

namespace Mews.Fiscalization.Italy.Tests
{
    [TestFixture]
    public class SerializationTests
    {
        [Test]
        public void Test()
        {
            var generalData = new GeneralDocumentData
            {
                Art73 = Art73Type.SI
            };

            var serialized = XmlManipulator.Serialize(generalData);
        }
    }
}
