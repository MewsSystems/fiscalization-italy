using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Italy.Dto
{
    internal static class DtoUtils
    {
        public static decimal NormalizeDecimal(decimal value, int precision = 2)
        {
            return Math.Round(value + 0.00m, precision);
        }

        public static decimal? NormalizeDecimal(decimal? value, int precision = 2)
        {
            return value == null ? value : NormalizeDecimal(value.Value, precision);
        }

        public static string NormalizeZip(this string zip)
        {
            return Regex.Replace(zip, "[^0-9]", "");
        }

        public static string NormalizeString(this string s, bool extendedAscii = true)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return s;
            }

            var highestCharacter = extendedAscii ? 255 : 127;
            var strippedValue = StripDiacritics(s);
            var chars = s.Select((c, i) => (int) c <= highestCharacter ? c : strippedValue[i]).ToArray();
            return new String(chars);
        }

        private static string StripDiacritics(string s)
        {
            var simpleChars = s.Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            return new String(simpleChars.ToArray());
        }
    }
}
