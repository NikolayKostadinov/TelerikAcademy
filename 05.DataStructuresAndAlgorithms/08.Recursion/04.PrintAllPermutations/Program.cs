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

            PrintPermutations(n, inputArr);
        }

        private static void PrintPermutations(int n, int[] result)
        {
            if (n == 0)
            {
                Console.WriteLine("{" + string.Join(", ", result) + "}");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                int oldValue = result[i];
                result[i] = result[n-1];
                result[n - 1] = oldValue;
                PrintPermutations(n - 1, result);
                oldValue = result[i];
                result[i] = result[n - 1];
                result[n - 1] = oldValue;
            }
        }
    }
}
