using System;

namespace _01.Array20
{
    class Array20
    {
        static void Main()
        {
            int[] array20 = new int[20];
            for (int index = 0; index < array20.Length ; index++)
            {
                array20[index] = index * 5;
                Console.WriteLine(array20[index]);
            }

        }
    }
}
