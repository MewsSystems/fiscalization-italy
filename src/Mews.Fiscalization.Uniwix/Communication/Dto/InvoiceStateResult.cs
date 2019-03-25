using Newtonsoft.Json;

namespace Mews.Fiscalization.Uniwix.Communication.Dto
{
    internal class InvoiceStateResult
    {
        [JsonProperty("stato_sdi")]
        public string SdiStatus { get; set; }
    }
}