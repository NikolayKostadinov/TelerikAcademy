/* TODO: Напишете програма, която извлича от даден текст всички изречения, 
 * които съдържат определена дума. Считаме, че изреченията са разделени 
 * едно от друго със символа ".", а думите са разделени една от друга със 
 * символ, който не е буква. 
 * Примерен текст:
 * We are living in a yellow submarine. We don't have anything
 * else. Inside the submarine is very tight. So we are drinking 
 * all the day. We will move out of it in 5 days.
 * Примерен резултат:
 * We are living in a yellow submarine.
 * We will move out of it in 5 days. */
 
namespace _10.FounSentences
{
    using System;
    using System.Text;

    public class FoundSentences
    {
        public static void Main()
        {
            string inputText = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days. But it is inpossible";
            string wantedWord = "in";
            StringBuilder reconstructor = new StringBuilder();
            string[] sentences = inputText.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(" ,-;:\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (Array.IndexOf(words, wantedWord) != -1) 
                {
                    reconstructor.Append(sentence.Trim());
                    reconstructor.Append(".\n\r");
                }
            }

            // removing last newline cartrige-return
            if (reconstructor.Length > 0)
            {
                reconstructor = reconstructor.Remove(reconstructor.Length - 2, 2); 
            }

            Console.WriteLine(reconstructor);
        }
    }
}
