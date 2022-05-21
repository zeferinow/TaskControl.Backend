using HtmlAgilityPack;
using MongoDB.Bson;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TaskControl.Backend.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharacterToLower(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str, 0))
            {
                return str;
            }

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public static string FirstCharacterToUpper(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str, 0))
            {
                return str;
            }

            return char.ToUpperInvariant(str[0]) + str.Substring(1);
        }

        public static byte[] ToBytesUtf8Encoding(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static byte[] ToBytesUtf8BomEncoding(this string value)
        {
            return Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(value)).ToArray();
        }

        public static byte[] ToBytesUtf8BomEncoding(this byte[] value)
        {
            return Encoding.UTF8.GetPreamble().Concat(value).ToArray();
        }

        public static byte[] ToByteArray(this string value)
        {
            var bytes = new byte[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                bytes[i] = (byte)value[i];
            }
            return bytes;
        }

        public static string ToPlainText(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(str);
            return htmlDoc.DocumentNode.InnerText;
        }

        public static string TrimEnd(this string text, string value, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            if (!string.IsNullOrEmpty(value))
            {
                while (!string.IsNullOrEmpty(text) && text.EndsWith(value, comparisonType))
                {
                    text = text.Substring(0, text.Length - value.Length);
                }
            }

            return text;
        }

        public static string RemoveDiacritics(this string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
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

            return text;
        }

        public static string RemoveAccents(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }

        public static ObjectId? ToNullableObjectId(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return ToObjectId(text);
        }

        public static ObjectId ToObjectId(this string text)
        {
            return ObjectId.Parse(text);
        }

        public static string RemoveHtmlDataIdValues(this string str)
        {
            return Regex.Replace(str, "data-id=\".*?\"", "", RegexOptions.Compiled);
        }

        public static string ToBase64(this string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        public static string FromBase64(this string input)
        {
            var bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string GetOnlyNumbers(this string str)
        {
            return Regex.Replace(str, @"[^\d]", "");
        }

        public static bool OnlyNumbers(this string str)
        {
            return Regex.IsMatch(str, @"^\d+$");
        }

        public static string RemoveTagStyle(this string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                return Regex.Replace(text, "(<style.+?</style>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }

            return text;
        }
    }
}