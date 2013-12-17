namespace PrintingAllVariationsKelementFromNelements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            int[] set1 = { 1, 2, 3 }; 
            string[] set = { "hi", "a", "b" };

            PrintAllVastiations<string>(0, set, new string[k]);
            Console.Write("\b\b ");
            Console.WriteLine();
        }

        private static void PrintAllVastiations<T>(int currentIndex, T[] set, T[] result)
        {
            if (currentIndex == result.Length)
            {
                Console.Write("(" + string.Join(" ", result) + "), ");
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                result[currentIndex] = set[i];
                PrintAllVastiations<T>(currentIndex + 1, set, result);
            }
        }
    }
}
