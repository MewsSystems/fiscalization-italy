using Newtonsoft.Json;

namespace Mews.Fiscalization.Uniwix.Communication
{
    internal class UniwixPostInvoiceResponseResult
    {
        [JsonProperty("fid")]
        public string FileId { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}