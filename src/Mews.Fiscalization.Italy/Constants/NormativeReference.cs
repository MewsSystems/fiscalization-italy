using System;
using Mews.Fiscalization.Italy.Dto.Invoice;

namespace Mews.Fiscalization.Italy.Constants
{
    public static class NormativeReference
    {
        public const string NotSubject = "non soggette";

        public static string GetByInvoiceLineKind(TaxKind taxKind)
        {
            switch (taxKind)
            {
                case TaxKind.NotSubject:
                    return NotSubject;
            }

            throw new InvalidOperationException("Unsupported invoice line kind.");
        }
    }
}
