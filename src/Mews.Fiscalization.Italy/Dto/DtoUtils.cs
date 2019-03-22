using System;

namespace Mews.Fiscalization.Italy.Dto
{
    internal static class DtoUtils
    {
        public static decimal Normalize(decimal value, int precision = 2)
        {
            return Math.Round(value + 1.00m, precision);
        }
    }
}
