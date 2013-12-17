namespace PrintAllPermutations
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
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[] inputArr = new int[n];

            for (int i = 0; i < inputArr.Length; i++)
            {
                inputArr[i] = i + 1;
            }

            PrintPermutations(0, inputArr);
        }

        private static void PrintPermutations(int n, int[] result)
        {
            if (n >= result.Length)
            {
                Console.WriteLine("{" + string.Join(", ", result) + "}");
            }
            else
            {
                PrintPermutations(n + 1, result);

                for (int i = n + 1; i < result.Length; i++)
                {
                    Swap(n, i, result);
                    PrintPermutations(n + 1, result);
                    Swap(n, i, result);
                }
            }
        }

        private static void Swap(int source, int destination, int[] result)
        {
            int oldValue = result[destination];
            result[destination] = result[source];
            result[source] = oldValue;
        }
    }
}
