namespace FindTheMajorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            Dictionary<int, int> counters = CountMembers(inputList);
            List<int> majorants = FindMajorantsIfEvist(counters, inputList.Count());
            
            if (majorants.Count == 0)
            {
                Console.WriteLine("The majorant does not exists!");
            }
            else
            {
                foreach (var majorant in majorants)
                {
                    Console.WriteLine(majorant);
                }
            }
        }

        private static List<int> FindMajorantsIfEvist(Dictionary<int, int> counters, int lenght)
        {
            List<int> majorants = new List<int>();
            int majorantCondition = (lenght/2) + 1;
            
            foreach (var counter in counters)
            {
                if (counter.Value >= majorantCondition)
                {
                    majorants.Add(counter.Key);
                }
            }

            return majorants;
        }

        private static Dictionary<int, int> CountMembers(List<int> inputList)
        {
            Dictionary<int, int> counters = new Dictionary<int, int>();
            for (int i = 0; i < inputList.Count; i++)
            {
                if (counters.ContainsKey(inputList[i]))
                {
                    counters[inputList[i]]++;
                }
                else
                {
                    counters.Add(inputList[i], 1);
                }
            }
            return counters;
        }
    }
}
