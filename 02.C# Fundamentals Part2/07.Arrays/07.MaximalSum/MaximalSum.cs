using System;

namespace _07.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            int n = 10;
            int k = 3;
            int[] arr = { 9, 6, 2, 7, 4, 7, 6, 5, 8, 4 };
            int maxSum = int.MinValue;
            int index = 0;
            for (int x = 0; x < arr.Length - k; x++)
            {
                int currSum = 0;

                for (int i = x; i < x+k; i++)
                {
                    currSum = currSum + arr[i];
                }
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    index = x;
                }
            }

            Console.WriteLine();

            for (int i = index; i < index+k; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine(maxSum);
        }
    }
}
