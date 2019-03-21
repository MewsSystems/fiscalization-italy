using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mews.Fiscalization.Italy;
using Mews.Fiscalization.Italy.Dto.Invoice;
using Mews.Fiscalization.Uniwix.Communication.Dto;
using Mews.Fiscalization.Uniwix.Dto;
using Newtonsoft.Json;

namespace Mews.Fiscalization.Uniwix.Communication
{
    public class UniwixClient : IDisposable
    {
        private const string UniwixBaseUrl = "https://www.uniwix.com/api/Uniwix";

        public UniwixClient(UniwixClientConfiguration configuration)
        {
            HttpClient = GetHttpClient(configuration);
        }

        private HttpClient HttpClient { get;}

        public async Task<SendInvoiceResult> SendInvoiceAsync(ElectronicInvoice invoice)
        {
            var url = $"{UniwixBaseUrl}/Invoices/Upload";
            var xml = XmlManipulator.SerializeToString(invoice);
            var xmlBytes = Encoding.UTF8.GetBytes(xml);
            var fileName = $"{invoice.Header.TransmissionData.SequentialNumber}.xml";
            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(xmlBytes), "fattura", fileName }
            };

            using (var response = await HttpClient.PostAsync(url, content).ConfigureAwait(continueOnCapturedContext: false))
            {
                var uniwixResponse = await ReadJsonResponse<UniwixPostInvoiceResponseResult>(response).ConfigureAwait(continueOnCapturedContext: false);
                if (uniwixResponse.Code != 0)
                {
                    throw new Exception("Something is wrong.");
                }

                return new SendInvoiceResult(uniwixResponse.Result.FileId);
            }
        }

        public async Task<InvoiceStatus> GetInvoiceStatusAsync(string invoiceFileId)
        {
            var url = $"{UniwixBaseUrl}/Invoices/{invoiceFileId}";
            using (var response = await HttpClient.GetAsync(url).ConfigureAwait(continueOnCapturedContext: false))
            {
                var uniwixResponse = await ReadJsonResponse<List<InvoiceStatus>>(response).ConfigureAwait(continueOnCapturedContext: false);
                return uniwixResponse.Result.First();
            }
        }

        public async Task<UniwixUser> CreateUserAsync(CreateUserParameters createUserParameters)
        {
            var url = $"{UniwixBaseUrl}/Users";
            var content = new MultipartFormDataContent
            {
                { new StringContent(createUserParameters.UserName), "username" },
                { new StringContent(createUserParameters.TaxIdentificationNumber), "piva" },
                { new StringContent(createUserParameters.Description), "descrizione" },
            };

            using (var response = await HttpClient.PostAsync(url, content).ConfigureAwait(continueOnCapturedContext: false))
            {
                return (await ReadJsonResponse<UniwixUser>(response).ConfigureAwait(continueOnCapturedContext: false)).Result;
            }
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }

        private async Task<UniwixResponse<TResult>> ReadJsonResponse<TResult>(HttpResponseMessage response)
        {
            var rawJson = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            return JsonConvert.DeserializeObject<UniwixResponse<TResult>>(rawJson);
        }

        private HttpClient GetHttpClient(UniwixClientConfiguration configuration)
        {
            var httpClient = new HttpClient();
            var credentials = $"{configuration.Key}:{configuration.Password}";
            var authenticationHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authenticationHeaderValue);

            return httpClient;
        }
    }
}