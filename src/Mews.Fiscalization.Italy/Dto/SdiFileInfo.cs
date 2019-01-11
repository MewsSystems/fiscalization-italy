using System;

namespace Mews.Fiscalization.Italy.Dto
{
    public class SdiFileInfo
    {
        public SdiFileInfo(DateTime receivedUtc, long sdiIdentifier)
        {
            ReceivedUtc = receivedUtc;
            SdiIdentifier = sdiIdentifier;
        }

        public DateTime ReceivedUtc { get; }

        public long SdiIdentifier { get; }
    }
}