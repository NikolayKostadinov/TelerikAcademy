/* TODO: Даден е текст. Напишете програма, която променя регистъра на 
 * буквите до главни на всички места в текста, заградени с таговете 
 * <upcase> и </upcase>. Таговете не могат да бъдат вложени.*/

namespace ChangeToUpperCase
{
    using System;
    using System.Text;

    public class ChangeToUpperCase
    {
        public static void Main(string[] args)
        {
            string text = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            StringBuilder result = TextToUpper(text, "<upcase>", "</upcase>");
            Console.WriteLine("Text before transformation: ");
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("Text after transformation");
            Console.WriteLine(result);
        }

        private static StringBuilder TextToUpper(string text, string openSep, string closeSep)
        {
            text = text.Replace(openSep, "\u0001");
            text = text.Replace(closeSep, "\u0002");
            StringBuilder result = new StringBuilder();

            string[] splitText = text.Split('\u0002');

            for (int i = 0; i < splitText.Length; i++)
            {
                int index = splitText[i].IndexOf('\u0001');
                int len = splitText[i].Length;

                if (index != -1)
                {                
                    result.Append(splitText[i].Substring(0, len - (len - index)));
                    splitText[i] = splitText[i].Substring(index, len - index).ToUpper();
                    result.Append(splitText[i]);
                    result.Append(closeSep);
                }
                else
                {
                    result.Append(splitText[i]);
                }
            }

            result.Replace("\u0001", "<upcase>");
            return result;
        }
    }
}
