namespace Mews.Fiscalization.Uniwix.Dto
{
    public class InvoiceState
    {
        public InvoiceState(string fileId, SdiState state)
        {
            FileId = fileId;
            State = state;
        }

        public string FileId { get; }

        public SdiState State { get; }
    }
}