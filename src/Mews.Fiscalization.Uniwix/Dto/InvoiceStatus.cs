namespace Mews.Fiscalization.Uniwix.Dto
{
    public class InvoiceStatus
    {
        public InvoiceStatus(string fileId, string sdiStatus, string status)
        {
            FileId = fileId;
            SdiStatus = sdiStatus;
            Status = status;
        }

        public string FileId { get; }

        public string SdiStatus { get; }

        public string Status { get; }
    }
}