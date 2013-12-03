namespace _02.ReverseInput
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads N integers from the console and 
    /// reverses them using a stack. Use the Stack<int> class.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfIntegers = ReadNumberOfIntegersFromConsole();
            Stack<int> inputSequence = ReadIntegersFromConsole(numberOfIntegers);
            WriteIntegersOnConsole(inputSequence);
        }

        private static int ReadNumberOfIntegersFromConsole()
        {
            int numberOfEntries = 0;
            Console.Write("Pleace enter number of entries in the sequence: ");
            while (true)
            {
                bool isIntegerNumber = int.TryParse(Console.ReadLine(), out numberOfEntries);
                bool isPositiveNumber = isIntegerNumber && (numberOfEntries > 0);
                if (isPositiveNumber)
                {
                    return numberOfEntries;
                }
                else
                {
                    Console.WriteLine("The entry must be positive integer number");
                    Console.Write("Pleace enter number of entries in the sequence: ");
                }
            }
       }

        private static Stack<int> ReadIntegersFromConsole(int numberOfIntegers)
        {
            Stack<int> readedSequence = new Stack<int>(numberOfIntegers);
            int indexer = 0;
            do
            {
                Console.Write("Enter member nomber[{0}]: ", indexer);
                string inputString = Console.ReadLine();
                int convertedNumber = 0;
                bool isInputStringANumbet = int.TryParse(inputString, out convertedNumber);
                
                if (isInputStringANumbet)
                {
                    readedSequence.Push(convertedNumber);
                    indexer++;
                    if (indexer >= numberOfIntegers)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("The entry must be a positive number !");
                }
            }
            while (true);

            return readedSequence;
        }

        private static void WriteIntegersOnConsole(Stack<int> inputSequence)
        {
            while (inputSequence.Count > 0)
            {
                int currentElement = inputSequence.Pop();
                Console.WriteLine(currentElement);
            }
        }
    }
}
