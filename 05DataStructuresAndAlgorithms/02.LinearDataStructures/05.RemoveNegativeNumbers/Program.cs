namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { 1, -1, 2, -2, 3, -3 };
            List<int> outputList = GetPositiveNumbersFromList(inputList);
            Console.WriteLine(string.Join(", ", inputList)); 
            Console.WriteLine(string.Join(", ", outputList));
        }

        private static List<int> GetPositiveNumbersFromList(List<int> inputList)
        {
            List<int> positiveNumbers = new List<int>();

            if (inputList.Count > 0)
            {

                foreach (var number in inputList)
                {
                    if (number >= 0)
                    {
                        positiveNumbers.Add(number);
                    }
                }
            }

            return positiveNumbers;
        }
    }
}
