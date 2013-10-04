/* TODO: Напишете програма, която обръща думите в дадено изречение 
 * без да променя пунктуацията и интервалите. 
 * Например: 
 * "C# is not C++ and PHP is not Delphi" -> "Delphi not is PHP and C++ not is C#".
 */

namespace _14.MirorSentence
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class MirorSentense
    {
        public static void Main(string[] args)
        {
            string text = @"C# is not ""C++ and PHP"" is not Delphi!";
            string pattern = @".*?[\s]|.*?$";
            StringBuilder newString = new StringBuilder(text.Length);
            Console.WriteLine(text);
            MirorSplit(text, newString);
            newString.Clear();
            MirorRegex(text, pattern, newString);
            Console.ReadKey();   
        }

        private static void MirorRegex(string text, string pattern, StringBuilder newString)
        {
            DateTime begin = DateTime.Now;
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnorePatternWhitespace);
            foreach (Match match in matches)
            {
                newString.Insert(0, match.Value.TrimEnd("',?!\" ".ToCharArray()) + " ");
            }

            Console.WriteLine(newString);
            Console.WriteLine(DateTime.Now - begin);
        }

        private static void MirorSplit(string text, StringBuilder newString)
        {
            DateTime begin = DateTime.Now;
            string[] words = text.Split();
            foreach (string word in words)
            {
                newString.Insert(0, word + " ");
            }

            Console.WriteLine(newString);
            Console.WriteLine(DateTime.Now - begin);
        }
    }
}
