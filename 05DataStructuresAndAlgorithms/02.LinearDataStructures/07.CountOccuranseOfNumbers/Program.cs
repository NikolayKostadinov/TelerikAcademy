namespace CountOccuranseOfNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2, 1 };
            SortedDictionary<int, int> counters = CountMembers(inputList);
            foreach (var counter in counters) 
            {
                string numberOfOccurens = counter.Value > 1 ? counter.Value + " times" : counter.Value + " time";
                Console.WriteLine("{0} -> {1}", counter.Key, numberOfOccurens);
            }
            
        }

        private static SortedDictionary<int, int> CountMembers(List<int> copyList)
        {
            SortedDictionary<int, int> counters = new SortedDictionary<int, int>();
            for (int i = 0; i < copyList.Count; i++)
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
            return counters;
        }
    }
}
