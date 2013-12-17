namespace PrintingAllCombinationsWithDuplicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PrintingAllCombinationsWithDuplicates
    {
        private static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine()); 

            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            
            PrintingAllCombinations(k, n, 0, 0, new int[k]);
        }

        private static void PrintingAllCombinations(int k, int n, int index, int startValue, int[] result)
        {
            if(index == k)
            {
                Console.Write("(" + string.Join(" ",result)+ "), ");
                return;
            }

            for (int j = startValue; j < n; j++)
            {
                result[index] = j + 1;
                PrintingAllCombinations(k, n, index + 1, j, result);
            }

        }
    }
}
