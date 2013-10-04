/* TODO: Даден е символен низ, съставен от няколко "забранени" думи, разде-лени със запетая. 
 * Даден е и текст, съдържащ тези думи. Да се напише програма, която замества забранените 
 * думи в текста със звездички. 
 * Примерен текст:
 * Microsoft announced its next generation C# compiler today. 
 * It uses advanced parser and special optimizer for the Microsoft CLR.
 * Примерен низ от забранените думи: 
 * "C#,CLR,Microsoft    ".
 * Примерен съответен резултат:
 ********* announced its next generation ** compiler today. 
 *It uses advanced parser and special optimizer for the ********* ***.
 */

namespace _11.ForbidenWords
{
    using System;
    using System.Text;

    public class ForbidenWords
    {
        public static void Main()
        {
            string[] forbidenWords = "C#,CLR,Microsoft".Split(',');
            StringBuilder inputText = new StringBuilder("Microsoft announced its next generation C# compiler today. It uses advanced parser and special optimizer for the Microsoft CLR.");

            foreach (string forbidenWord in forbidenWords)
            {
                inputText.Replace(
                    forbidenWord, 
                    string.Empty.PadLeft(forbidenWord.Length, '*'));
            }

            Console.WriteLine(inputText);
        }
    }
}
