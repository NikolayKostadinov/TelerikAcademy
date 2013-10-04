/* TODO: Напишете програма, която чете от конзолата стринг 
 * от максимум 20 символа и ако е по-кратък го допълва 
 * отдясно със "*" до 20 символа.*/
 
namespace _07.String20
{
    using System;
    using System.IO;

    public class String20
    {
        public static void Main()
        {
            Console.Write("Please enter string no longer than 20 symbols: ");
            try
            {
                string inputString = ConsoleRead20();
                inputString = FormatString20(inputString);
                Console.WriteLine(inputString);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("Fatal Error! " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string ConsoleRead20()
        {
            string text = Console.ReadLine();
            if (text.Length > 20)
            {
                throw new ArgumentOutOfRangeException(
                    "text", "The input text must be  no longer than 20 symbols!");
            }

            return text;
        }

        private static string FormatString20(string text)
        {
            if (text.Length < 20)
            {
                text = text.PadRight(20, '*');
            }

            return text;
        }
    }
}
