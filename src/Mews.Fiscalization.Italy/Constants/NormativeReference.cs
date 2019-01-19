using System;
using Mews.Fiscalization.Italy.Dto;
using Mews.Fiscalization.Italy.Dto.Invoice;

namespace Mews.Fiscalization.Italy.Constants
{
    public static class NormativeReference
    {
        public const string NotTaxable = "";
        public const string ReversePayment = "";

        public static string GetByInvoiceLineKind(TaxKind taxKind)
        {
            switch (taxKind)
            {
                case TaxKind.NotTaxable:
                    return NotTaxable;
                case TaxKind.ReverseCharge:
                    return ReversePayment;
            }

            throw new InvalidOperationException("Unsupported invoice line kind.");
        }
    }
}
