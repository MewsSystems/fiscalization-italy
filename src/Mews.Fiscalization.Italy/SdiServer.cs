using System.Text;
using System.Xml;
using FuncSharp;
using Mews.Fiscalization.Italy.Communication;
using Mews.Fiscalization.Italy.Dto.Notifications;
using Mews.Fiscalization.Italy.Http;

namespace Mews.Fiscalization.Italy
{
    public class SdiNotificationActions
    {
        public const string DeliveryReceiptNotification = "http://www.fatturapa.it/TrasmissioneFatture/RicevutaConsegna";
        public const string FailedDeliveryNotification = "http://www.fatturapa.it/TrasmissioneFatture/NotificaMancataConsegna";
        public const string RejectionNotification = "http://www.fatturapa.it/TrasmissioneFatture/NotificaScarto";
        public const string OutcomeNotification = "http://www.fatturapa.it/TrasmissioneFatture/NotificaEsito";
        public const string DeadlinePassedNotification = "http://www.fatturapa.it/TrasmissioneFatture/NotificaDecorrenzaTermini";
        public const string ImpossibleDeliveryNotification = "http://www.fatturapa.it/TrasmissioneFatture/AttestazioneTrasmissioneFattura";
    }

    public class TypedSdiNotification : Coproduct1<DeliveryReceiptNotification>
    {
        public TypedSdiNotification(SdiNotification notification)
            : base(notification.AsCoproduct<DeliveryReceiptNotification>())
        {
        }
    }

    public class SdiServer
    {
        public TypedSdiNotification ParseNotification(HttpRequest httpRequest)
        {
            var soapAction = httpRequest.Headers.Get("SOAPAction").GetOrNull() ?? "Missing SOAP action.";
            return soapAction.Match(
                SdiNotificationActions.DeliveryReceiptNotification, _ => ParseNotification<DeliveryReceiptNotification>(httpRequest),
                SdiNotificationActions.FailedDeliveryNotification, _ => ParseNotification<FailedDeliveryNotification>(httpRequest),
                SdiNotificationActions.RejectionNotification, _ => ParseNotification<RejectionNotification>(httpRequest),
                SdiNotificationActions.OutcomeNotification, _ => ParseNotification<OutcomeNotification>(httpRequest),
                SdiNotificationActions.DeadlinePassedNotification, _ => ParseNotification<DeadlinePassedNotification>(httpRequest),
                SdiNotificationActions.ImpossibleDeliveryNotification, _ => ParseNotification<ImpossibleDeliveryNotification>(httpRequest)
            );
        }

        private TypedSdiNotification ParseNotification<TNotification>(HttpRequest httpRequest)
            where TNotification : SdiNotification, new()
        {
            var soapBody = GetSoapBody(httpRequest.Content.Value);
            var notificationFile = XmlManipulator.Deserialize<SdiNotificationFile>(soapBody);

            var notificationXml = Encoding.UTF8.GetString(notificationFile.FileContent);
            var notificationXmlDocument = new XmlDocument();
            notificationXmlDocument.LoadXml(notificationXml);

            var notification = XmlManipulator.Deserialize<TNotification>(notificationXmlDocument.DocumentElement);
            return new TypedSdiNotification(notification);
        }

        private XmlElement GetSoapBody(string soapXmlString)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(soapXmlString);

            var soapMessage = SoapMessage.FromSoapXml(xmlDocument);
            return soapMessage.Body.XmlElement.FirstChild as XmlElement;
        }
    }
}
