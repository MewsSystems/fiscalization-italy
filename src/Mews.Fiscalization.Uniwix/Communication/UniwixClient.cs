using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mews.Fiscalization.Italy;
using Mews.Fiscalization.Italy.Dto.Invoice;
using Newtonsoft.Json;

namespace Mews.Fiscalization.Uniwix.Communication
{
    public class UniwixClient
    {
        private const string UniwixBaseUrl = "https://www.uniwix.com/api/Uniwix";

        public UniwixClient(UniwixClientConfiguration configuration)
        {
            Configuration = configuration;
        }

        private UniwixClientConfiguration Configuration { get; }

        public async Task<UniwixClientResult> ReportInvoiceAsync(ElectronicInvoice invoice)
        {
            var url = $"{UniwixBaseUrl}/Invoices/Upload";
            var xml = GetInvoiceXml(invoice);
            var xmlBytes = Encoding.UTF8.GetBytes(xml);
            var fileName = $"{invoice.Header.TransmissionData.SequentialNumber}.xml";
            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(xmlBytes), "fattura", fileName }
            };

            using (var httpClient = GetHttpClient())
            using (var response = await httpClient.PostAsync(url, content).ConfigureAwait(continueOnCapturedContext: false))
            {
                var uniwixResponse = await ReadJsonResponse<UniwixPostInvoiceResponseResult>(response).ConfigureAwait(continueOnCapturedContext: false);
                if (uniwixResponse.Code != 0)
                {
                    throw new Exception("Something is wrong.");
                }

                return new UniwixClientResult(uniwixResponse.Result.FileId);
            }
        }

        public async Task<UniwixInvoiceStatus> GetInvoiceStatusAsync(string invoiceFileId)
        {
            var url = $"{UniwixBaseUrl}/Invoices/{invoiceFileId}";
            using (var httpClient = GetHttpClient())
            using (var response = await httpClient.GetAsync(url).ConfigureAwait(continueOnCapturedContext: false))
            {
                var uniwixResponse = await ReadJsonResponse<List<UniwixInvoiceStatus>>(response).ConfigureAwait(continueOnCapturedContext: false);
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

            using (var httpClient = GetHttpClient())
            using (var response = await httpClient.PostAsync(url, content).ConfigureAwait(continueOnCapturedContext: false))
            {
                return (await ReadJsonResponse<UniwixUser>(response).ConfigureAwait(continueOnCapturedContext: false)).Result;
            }
        }

        private async Task<UniwixResponseWrapper<TResult>> ReadJsonResponse<TResult>(HttpResponseMessage response)
        {
            var rawJson = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            return JsonConvert.DeserializeObject<UniwixResponseWrapper<TResult>>(rawJson);
        }

        private string GetInvoiceXml(ElectronicInvoice invoice)
        {
            var xmlDocument = XmlManipulator.Serialize(invoice);
            return xmlDocument.OuterXml;
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            var credentials = $"{Configuration.Key}:{Configuration.Password}";
            var authenticationHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authenticationHeaderValue);

            return httpClient;
        }
    }

    public class UniwixClientConfiguration
    {
        public UniwixClientConfiguration(string key, string password)
        {
            Key = key;
            Password = password;
        }

        public string Key { get; }

        public string Password { get; }
    }

    public class UniwixClientResult
    {
        public UniwixClientResult(string fileId)
        {
            FileId = fileId;
        }

        public string FileId { get; }
    }

    public class UniwixInvoiceStatus
    {
        public UniwixInvoiceStatus(string fileId, string sdiStatus, string status)
        {
            FileId = fileId;
            SdiStatus = sdiStatus;
            Status = status;
        }

        public string FileId { get; }

        public string SdiStatus { get; }

        public string Status { get; }
    }

    public class UniwixPostInvoiceResponseResult
    {
        [JsonProperty("fid")]
        public string FileId { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }

    public class UniwixResponseWrapper<TResponse>
    {
        public int Code { get; set; }

        public TResponse Result { get; set; }
    }

    public class CreateUserParameters
    {
        public CreateUserParameters(string taxIdentificationNumber, string userName, string description)
        {
            TaxIdentificationNumber = taxIdentificationNumber;
            UserName = userName;
            Description = description;
        }

        public string TaxIdentificationNumber { get; }

        public string UserName { get; }

        public string Description { get; }
    }

    public class UniwixUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonProperty("bridge_key")]
        public string BridgeKey { get; set; }

        [JsonProperty("piva")]
        public string TaxIdentificationNumber { get; set; }

        [JsonProperty("descrizione")]
        public string Description { get; set; }
    }
}