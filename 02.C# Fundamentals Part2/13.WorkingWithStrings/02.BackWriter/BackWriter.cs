/* TODO: Напишете програма, която прочита символен низ, 
 * обръща го отзад напред и го принтира на конзолата. 
 * Например: "introduction" -> "noitcudortni". */

namespace _02.BackWriter
{
    using System;
    using System.Text;

    public class BackWriter
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            StringBuilder outputString = new StringBuilder(inputString.Length);

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                outputString.Append(inputString[i]);
            }

            Console.WriteLine(outputString);
        }
    }
}
