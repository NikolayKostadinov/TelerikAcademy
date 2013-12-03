namespace RemoveFromSequenceOddTimesMembers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> outputList = GetEvencountMembers(inputList);
            Console.WriteLine(string.Join(", ", inputList));
            Console.WriteLine(string.Join(", ", outputList));
        }

        /// <summary>
        /// Write a program that removes from given sequence all numbers that occur odd number of times. 
        /// </summary>
        /// <returns>WantedList</returns>
        private static List<int> GetEvencountMembers(List<int> inputList)
        {
            int[] copyList = new int[inputList.Count];
            Dictionary<int, int> counters = new Dictionary<int, int>();
            inputList.CopyTo(copyList);

            //count all members
            CountMembers(copyList, counters);

            //maiking asked result
            List<int> result = CopyOnlyEven(inputList, counters);
            return result;
        }

        private static void CountMembers(int[] copyList, Dictionary<int, int> counters)
        {
            for (int i = 0; i < copyList.Length; i++)
            {
                if (counters.ContainsKey(copyList[i]))
                {
                    counters[copyList[i]]++;
                }
                else
                {
                    counters.Add(copyList[i], 1);
                }
            }
        }

        private static List<int> CopyOnlyEven(List<int>inputList, Dictionary<int, int> counters)
        {
            List<int> result = new List<int>();
            foreach (var number in inputList)
            {
                if (counters[number] % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result;
        }
    }
}
