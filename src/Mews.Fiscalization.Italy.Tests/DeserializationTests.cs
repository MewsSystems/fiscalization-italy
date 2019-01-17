using System.Xml;
using Mews.Fiscalization.Italy.Dto.Notifications;
using NUnit.Framework;

namespace Mews.Fiscalization.Italy.Tests
{
    [TestFixture]
    public class DeserializationTests
    {
        [Test]
        public void TestA()
        {
            var xml = @"<ns1:attestazioneTrasmissioneFattura xmlns:ns1=""http://www.fatturapa.gov.it/sdi/ws/trasmissione/v1.0/types"">
                            <IdentificativoSdI>123</IdentificativoSdI>
                            <NomeFile>IT01234567890_11111_AT_001.xml</NomeFile>
                            <File>PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPD94bWwtc3R5bGVzaGVldCB0eXBlPSJ0ZXh0L3hzbCIgaHJlZj0iQVRfdjEuMS54c2wiPz4KPHR5cGVzOkF0dGVzdGF6aW9uZVRyYXNtaXNzaW9uZUZhdHR1cmEgeG1sbnM6dHlwZXM9Imh0dHA6Ly93d3cuZmF0dHVyYXBhLmdvdi5pdC9zZGkvbWVzc2FnZ2kvdjEuMCIgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSIgdmVyc2lvbmU9IjEuMCIgeHNpOnNjaGVtYUxvY2F0aW9uPSJodHRwOi8vd3d3LmZhdHR1cmFwYS5nb3YuaXQvc2RpL21lc3NhZ2dpL3YxLjAgTWVzc2FnZ2lUeXBlc192MS4xLnhzZCAiPgo8SWRlbnRpZmljYXRpdm9TZEk+MjE0PC9JZGVudGlmaWNhdGl2b1NkST4KPE5vbWVGaWxlPklUMDEyMzQ1Njc4OTBfMTExMTEueG1sLnA3bTwvTm9tZUZpbGU+CjxEYXRhT3JhUmljZXppb25lPjIwMTQtMDQtMDFUMTI6MDA6MDA8L0RhdGFPcmFSaWNlemlvbmU+CjxEZXN0aW5hdGFyaW8+CiAgICA8Q29kaWNlPkFBQUFBQTwvQ29kaWNlPgogICAgPERlc2NyaXppb25lPlB1YmJsaWNhIEFtbWluaXN0cmF6aW9uZSBkaSBwcm92YTwvRGVzY3JpemlvbmU+CjwvRGVzdGluYXRhcmlvPgo8TWVzc2FnZUlkPjEyMzQ1NjwvTWVzc2FnZUlkPgo8Tm90ZT5BdHRlc3RhemlvbmUgVHJhc21pc3Npb25lIEZhdHR1cmEgZGkgcHJvdmE8L05vdGU+CjxIYXNoRmlsZU9yaWdpbmFsZT4yYzFmM2EyNDBhMDU2ZDk1MzdhODYwOGZlZDMxMDgxMmVmN2IxYjdhNDEwZDAxNTJmNWM5YzllOTM0ODZhZTQ0PC9IYXNoRmlsZU9yaWdpbmFsZT4KPC90eXBlczpBdHRlc3RhemlvbmVUcmFzbWlzc2lvbmVGYXR0dXJhPg==</File>
                        </ns1:attestazioneTrasmissioneFattura>";

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            var deserialized = XmlManipulator.Deserialize<ImpossibleDeliveryNotification>(xmlDoc.DocumentElement);
        }
    }
}
