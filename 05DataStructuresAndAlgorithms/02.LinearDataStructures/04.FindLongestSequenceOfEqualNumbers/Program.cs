namespace FindLongestSequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            List<int> list = ReadSequenceOfIntegersFromConsole();
            List<int> result = list.GetMaximalSequenceOfEcual();
            
            for (int i = 0; i < result.Count; i++)
            {
               Console.WriteLine(result[i]);
            }
        }

        private static List<int> ReadSequenceOfIntegersFromConsole()
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

            return readedSequence;
        }        
    }

    
}
