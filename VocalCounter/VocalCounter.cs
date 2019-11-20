using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocalCounter
{
    public static class VocalCounter
    {
        public static readonly char[] _vocals = { 'a', 'e', 'i', 'o', 'u' };
        public static string Counter(string text)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.NormalizeVocals();
                var counter = text.Where(letter => _vocals.Contains(letter))
                    .GroupBy(letter => letter)
                    .Select(letter => new
                    {
                        Vocal = letter.Key,
                        Count = letter.Count()
                    });
                result = string.Join(", ", counter.Select(x => x.Vocal + " → " + x.Count).ToArray());
            }
            return result;
        }
        private static string NormalizeVocals(this string text)
        {
            var characters = text.Normalize(NormalizationForm.FormD)
                                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                    .ToArray();
            return new string(characters).Normalize(NormalizationForm.FormC).ToLower();
        }
    }
}
