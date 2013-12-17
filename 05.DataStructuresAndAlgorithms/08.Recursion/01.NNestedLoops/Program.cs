using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNestedLoops
{
    internal class Program
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            NestredLoops(n, 0, new int[n]);
        }

        private static void NestredLoops(int n, int numberOfLoops, int[] result)
        {

            if (numberOfLoops == n)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 0; i < n; i++)
			{
                result[numberOfLoops] = i + 1;
                NestredLoops(n, numberOfLoops + 1, result);
			}
        }
    }
}
