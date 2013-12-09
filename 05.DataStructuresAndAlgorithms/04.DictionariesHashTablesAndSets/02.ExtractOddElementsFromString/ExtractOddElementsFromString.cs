/*Write a program that extracts from a given sequence 
 * of strings all elements that present in it odd number of times. Example:
 * {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
 */
namespace ExtractOddElementsFromString
{
    using System;
    using System.Collections.Generic;

    public class ExtractOddElementsFromString
    {
        internal static void Main()
        {
            IList<string> inputStrings = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            IDictionary<string, int> coutersOfOccurances = new Dictionary<string, int>();
            CalculateNumberOfOccurances(inputStrings, coutersOfOccurances);
            List<string> outputList = FindOddCountElements(coutersOfOccurances);
            string outputString = string.Join(", ", outputList);
            Console.WriteLine(outputString);
        }

        private static List<string> FindOddCountElements(IDictionary<string, int> coutersOfOccurances)
        {
            List<string> outputList = new List<string>();
            foreach (var counter in coutersOfOccurances)
            {
                if (counter.Value % 2 != 0)
                {
                    outputList.Add(counter.Key);
                }
            }
            return outputList;
        }

        private static void CalculateNumberOfOccurances(IList<string> inputStrings, IDictionary<string, int> coutersOfOccurances)
        {
            foreach (var element in inputStrings)
            {
                if (coutersOfOccurances.ContainsKey(element))
                {
                    coutersOfOccurances[element]++;
                }
                else 
                {
                    coutersOfOccurances.Add(element, 1);
                }
            }
        }
    }
}
