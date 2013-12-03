namespace ReadSequenceOfPositiveNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. 
    /// The sequence ends when empty line is entered. Calculate and print the sum and average 
    /// of the elements of the sequence. Keep the sequence in List<int>.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> inputSequence = ReadSequenceFromConsole();
            long sumOfElements = CalsulateSumOfArrayElements(inputSequence);
            Console.WriteLine(sumOfElements);
            double averageOfElements = CalculareAverage(sumOfElements, inputSequence.Count());
            Console.WriteLine(averageOfElements);
        }

        private static List<int> ReadSequenceFromConsole()
        {
            List<int> readedSequence = new List<int>();
            do
            {
                string inputString = Console.ReadLine();
                if (inputString == string.Empty)
                {
                    break;
                }

                int convertedNumber = 0;
                bool isInputStringAPositiveNumbet = int.TryParse(inputString, out convertedNumber);
                isInputStringAPositiveNumbet = isInputStringAPositiveNumbet && (convertedNumber > 0);
                if (isInputStringAPositiveNumbet)
                {
                    readedSequence.Add(convertedNumber);
                }
                else 
                {
                    Console.WriteLine("The entry must be a positive number !");
                }
            } 
            while (true);

            return readedSequence;
        }

        private static long CalsulateSumOfArrayElements(List<int> inputSequence)
        {
            if (inputSequence.Count == 0) 
            {
                return 0;
            }

            long sumOfSequence = 0;

            foreach (var item in inputSequence)
            {
                sumOfSequence += item;
            }

            return sumOfSequence;
        }

        private static double CalculareAverage(long sumOfElements, int count)
        {
            if (count == 0)
            {
                return 0;
            }

            double average = sumOfElements / count;
            return average;
        }
    }
}
