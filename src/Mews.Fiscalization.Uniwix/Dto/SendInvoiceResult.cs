namespace Mews.Fiscalization.Uniwix.Dto
{
    public class SendInvoiceResult
    {
        public SendInvoiceResult(string fileId)
        {
            FileId = fileId;
        }

        public string FileId { get; }
    }
}