/* TODO: Напишете програма, която преобразува даден стринг 
 * във вид на поредица от Unicode екраниращи последователности. 
 * Примерен входен стринг: "Наков". 
 * Резултат: "\u041d\u0430\u043a\u043e\u0432".
 */

namespace _08.ConvertStringToUnicode
{
    using System;
    using System.Text;

    public class ConvertStringToUnicode
    {
        public static void Main()
        {
            string inputString = "Наков";
            Console.WriteLine(StringToUnicode(inputString));
        }

        private static string StringToUnicode(string text)
        {
            StringBuilder textReconstructor =
                new StringBuilder(text.Length);

            foreach (char symbol in text)
            {
                string charUnicode = "\\u" +
                    string.Format("{0:x}", (int)symbol).PadLeft(4, '0');
                textReconstructor.Append(charUnicode);
            }

            return textReconstructor.ToString();
        }
    }
}
