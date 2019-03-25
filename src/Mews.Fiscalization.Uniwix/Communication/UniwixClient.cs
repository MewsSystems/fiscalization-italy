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
    public class UniwixClient
    {
        private const string UniwixBaseUrl = "https://www.uniwix.com/api/Uniwix";

        static UniwixClient()
        {
            HttpClient = new HttpClient();
        }

        public UniwixClient(UniwixClientConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static HttpClient HttpClient { get;}

        private UniwixClientConfiguration Configuration { get; }

        public async Task<SendInvoiceResult> SendInvoiceAsync(ElectronicInvoice invoice)
        {
            var url = $"{UniwixBaseUrl}/Invoices/Upload";
            var file = new ElectronicInvoiceFile(invoice);
            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(file.Data), "fattura", file.FileName }
            };

            var result = await PostAsync<PostInvoiceResponse>(url, content).ConfigureAwait(continueOnCapturedContext: false);
            return new SendInvoiceResult(result.FileId);
        }

        public async Task<InvoiceState> GetInvoiceStateAsync(string fileId)
        {
            var url = $"{UniwixBaseUrl}/Invoices/{fileId}";
            var result = await GetAsync<List<InvoiceStateResult>>(url).ConfigureAwait(continueOnCapturedContext: false);
            var state = result.Single();
            return new InvoiceState(fileId, ParseSdiState(state.SdiStatus));
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

            return await PostAsync<UniwixUser>(url, content).ConfigureAwait(continueOnCapturedContext: false);
        }

        private SdiState ParseSdiState(string sdiState)
        {
            if (String.IsNullOrWhiteSpace(sdiState))
            {
                return SdiState.Pending;
            }

            throw new NotImplementedException("Support for other states is not implemented.");
        }

        private async Task<TResult> GetAsync<TResult>(string url)
        {
            return await ExecuteRequestAsync<TResult>(url, HttpMethod.Get).ConfigureAwait(continueOnCapturedContext: false);
        }

        private async Task<TResult> PostAsync<TResult>(string url, HttpContent content)
        {
            return await ExecuteRequestAsync<TResult>(url, HttpMethod.Post, content).ConfigureAwait(continueOnCapturedContext: false);
        }

        private async Task<TResult> ExecuteRequestAsync<TResult>(string url, HttpMethod httpMethod, HttpContent content = null)
        {
            var credentials = $"{Configuration.Key}:{Configuration.Password}";
            var authenticationHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));

            using (var message = new HttpRequestMessage())
            {
                message.RequestUri = new Uri(url);
                message.Content = content;
                message.Method = httpMethod;
                message.Headers.Authorization = new AuthenticationHeaderValue("Basic", authenticationHeaderValue);

                using (var httpResponse = await HttpClient.SendAsync(message).ConfigureAwait(continueOnCapturedContext: false))
                {
                    var json = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<Response<TResult>>(json).Result;
                    }

                    var errorResponse = JsonConvert.DeserializeObject<Response<string>>(json);
                    throw new UniwixException(errorResponse.Code, errorResponse.Result);
                }
            }
        }
    }
}