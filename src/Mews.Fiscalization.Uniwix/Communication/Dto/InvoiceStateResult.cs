using Newtonsoft.Json;

namespace Mews.Fiscalization.Uniwix.Communication.Dto
{
    internal class InvoiceStateResult
    {
        [JsonProperty("stato")]
        public UniwixProcesingState? State { get; set; }

        [JsonProperty("stato_sdi")]
        public string SdiState { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}