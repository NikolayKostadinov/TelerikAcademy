using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ParalelCaclulateOfChance
{
    class Program
    {
        static void Main(string[] args)
        {
            var begin = DateTime.Now;
            CaclulateSync();
            Console.WriteLine("Estimated time: {0}", DateTime.Now - begin);

            begin = DateTime.Now;
            CalculateAsynk();
            Console.WriteLine("Estimated time: {0}", DateTime.Now - begin);
        }

        /// <summary>
        /// Calculates the asynk.
        /// </summary>
        private static void CalculateAsynk()
        {
            BigInteger n = 49000;
            BigInteger r = 600;
            Task<BigInteger> part1 = Task.Factory.StartNew<BigInteger>(() => Factorial(n));
            Task<BigInteger> part2 = Task.Factory.StartNew<BigInteger>(() => Factorial(n - r));
            Task<BigInteger> part3 = Task.Factory.StartNew<BigInteger>(() => Factorial(r));
            BigInteger chances = part1.Result / (part2.Result * part3.Result);
            Console.WriteLine("The chance of winning is: {0}", chances);
        }

        /// <summary>
        /// Caclulates the sync.
        /// </summary>
        private static void CaclulateSync()
        {
            BigInteger n = 49000;
            BigInteger r = 600;
            BigInteger part1 = Factorial(n);
            BigInteger part2 = Factorial(n - r);
            BigInteger part3 = Factorial(r);
            BigInteger chances = part1 / (part2 * part3);
            Console.WriteLine("The chance of winning is: {0}", chances);
        }

        /// <summary>
        /// Factorials the specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        private static BigInteger Factorial(BigInteger n)
        {
            BigInteger result = 1;
            for (int i = 1; i < n + 1; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
