/*Write a program that counts in a given array of double values 
 * the number of occurrences of each value. Use Dictionary<TKey,TValue>.
Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
-2.5 -> 2 times
   3 -> 4 times
   4 -> 3 times
*/
namespace CalculateOccurrencesOfValueInArray
{
    using System;
    using System.Collections.Generic;

    public class CalculateOccurrencesOfValueInArray
    {
         internal static void Main()
        {
            List<double> inputArray = new List<double>() { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            IDictionary<double, int> occurancesCouters = new SortedDictionary<double, int>();
            CountOccurancesOfNumberInList(inputArray, occurancesCouters);
            PrintResultOnConsole(occurancesCouters);
        }

         private static void PrintResultOnConsole(IDictionary<double, int> occurancesCouters)
         {
             foreach (var counter in occurancesCouters)
             {
                 string endOfMessage = counter.Value.ToString() + ((counter.Value > 1) ? " times" : "time");
                 Console.WriteLine("{0} -> {1}", counter.Key, endOfMessage);
             }
         }

         private static void CountOccurancesOfNumberInList(List<double> inputArray, IDictionary<double, int> occurancesCouters)
         {
             foreach (var number in inputArray)
             {
                 if (occurancesCouters.ContainsKey(number))
                 {
                     occurancesCouters[number]++;
                 }
                 else
                 {
                     occurancesCouters.Add(number, 1);
                 }
             }
         }
    }
}
