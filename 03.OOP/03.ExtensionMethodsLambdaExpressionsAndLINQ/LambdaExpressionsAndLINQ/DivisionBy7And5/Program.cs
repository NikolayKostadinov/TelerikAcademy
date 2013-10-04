// Write a program that prints from given array of integers all numbers 4
// that are divisible by 7 and 3. Use the built-in extension methods and 
// lambda expressions. Rewrite the same with LINQ.

namespace DivisionBy7And5
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            PrintDevisible1();
            Console.WriteLine();
            PrintDevisible2();
        }

        // using extension methods and lambda expressions
        private static void PrintDevisible1()
        {
            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                arr[i] = i;
            }

            var arrResult = arr.Where(a => (a % 3 == 0 && a % 7 == 0));

            foreach (int item in arrResult)
            {
                Console.WriteLine(item);
            }
        }

        // Using LINQ
        private static void PrintDevisible2()
        {
            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                arr[i] = i;
            }

            var arrResult = from member in arr
                            where member % 3 == 0 && member % 7 == 0
                            select member;

            foreach (int item in arrResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}
