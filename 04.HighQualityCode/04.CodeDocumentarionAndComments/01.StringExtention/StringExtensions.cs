/// <summary>
/// StringExtentions
/// </summary>
namespace StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension methods library for System.String class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns MD5 checksum of given string. 
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <returns>MD5 checksum as System.String</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var bytesCollection = Encoding.UTF8.GetBytes(input);          
            var hashCodesOfInputData = md5Hash.ComputeHash(bytesCollection);
            var resultBytesCollector = new StringBuilder();
            
            for (int i = 0; i < hashCodesOfInputData.Length; i++)
            {
                resultBytesCollector.Append(hashCodesOfInputData[i].ToString("x2"));
            }

            return resultBytesCollector.ToString();
        }

        /// <summary>
        /// Convert given string to boolean value
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <returns>Returns boоlean value of given patterns: <value>"true", "ok", "yes", "1", "да"</value></returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Convert given string to short.
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <returns>Short value</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Convert given string to integer number.
        /// </summary>
        /// <param name="input">Current String</param>
        /// <returns>Integer number.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Convert given string to Long number.
        /// </summary>
        /// <param name="input">Current string</param>
        /// <returns>Long number.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts given string to date.
        /// </summary>
        /// <param name="input">Current string</param>
        /// <returns>DateTime value</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes first letter of given string.
        /// </summary>
        /// <param name="input">Current string</param>
        /// <returns>Given string with capitalized first character.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns substring from given string witch is between two strings starts from given index.
        /// </summary>
        /// <param name="input">Current string</param>
        /// <param name="startString">Start separator string</param>
        /// <param name="endString">End separator string</param>
        /// <param name="startFrom">Start index</param>
        /// <returns>String lying between two delimiters.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;

            bool isInputStringContainsStartAndEndDelimiters = !(input.Contains(startString) && input.Contains(endString));
            if (isInputStringContainsStartAndEndDelimiters)
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts Cyrillic letters to their Latin phonetic equivalent.
        /// </summary>
        /// <param name="input">Current String</param>
        /// <returns>Latin letter string</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts Latin letters to their Cyrillic phonetic equivalent.
        /// </summary>
        /// <param name="input">Current String</param>
        /// <returns>Cyrillic letter string</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Convert given string to valid user name.
        /// </summary>
        /// <param name="input">Current string</param>
        /// <returns>String that represents a valid user name</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            string validUserName = Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
            return validUserName;
        }

        /// <summary>
        /// Convert given string to valid file name in Latin.
        /// </summary>
        /// <param name="input">Current String</param>
        /// <returns>String that represents a valid filename in Latin</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets given number of characters from the given string starts from the beginning, 
        /// or whole string if number of asked string is greater than string length
        /// </summary>
        /// <param name="input">Current String.</param>
        /// <param name="charsCount">Number of chars</param>
        /// <returns>Returns asked number of characters or whole string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets suffix of given as string, file name 
        /// </summary>
        /// <param name="fileName">Current String</param>
        /// <returns>File name extension: ".exe", ".jpg" ....</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts a type of file given as string representing file suffix to its content type.
        /// </summary>
        /// <code>
        ///     string fileExtention = ".jpg";
        ///     string fileContentType = fileExtention.ToContentType();
        ///     Console.WriteLine(fileContentType);
        ///     ..........
        ///     Console Output:
        ///     ...
        ///     image/jpeg
        ///     >_
        /// </code>
        /// <param name="fileExtension">Current string</param>
        /// <returns> Content type of file</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Convert given string to array of bytes.
        /// </summary>
        /// <param name="input">Current string</param>
        /// <returns>Result array of bytes</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
