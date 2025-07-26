﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.TeamMembers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string input)
        {
            if (string.IsNullOrWhiteSpace(input) )
                return string.Empty;


            input = input.ToLowerInvariant();

            return CleanSlug(input );
            
        }

        private static string CleanSlug(string input)
        {
            var cleaned = Regex.Replace(input, @"[^a-z0-9\s-]", "");

            cleaned = Regex.Replace(cleaned, @"[\s-]+", "-");

            cleaned = cleaned.Trim('-');

            return cleaned;
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
