namespace SortIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that reads a sequence of integers (List<int>) 
    /// ending with an empty line and sorts them in an increasing order.
    /// </summary>
    public class Program
    {
        internal static void Main()
        {
            int[] inputSequence = ReadSequenceOfIntegersFromConsole();
            Array.Sort<int>(inputSequence, (n, m) => { return n - m; });
            foreach (var number in inputSequence)
            {
                Console.WriteLine(number);
            }
        }

        private static int[] ReadSequenceOfIntegersFromConsole()
        {
            List<int> readedSequence = new List<int>();
             
            do
            {
                Console.Write("Enter an integer or empty line: ");
                string inputString = Console.ReadLine();
                if (inputString == string.Empty)
                {
                    break;
                }

                int convertedNumber = 0;
                bool isInputStringANumbet = int.TryParse(inputString, out convertedNumber);
                if (isInputStringANumbet)
                {
                    readedSequence.Add(convertedNumber);
                }
                else
                {
                    Console.WriteLine("The entry must be a positive number !");
                }
            }
            while (true);

            return readedSequence.ToArray();
        }        
    }
}
