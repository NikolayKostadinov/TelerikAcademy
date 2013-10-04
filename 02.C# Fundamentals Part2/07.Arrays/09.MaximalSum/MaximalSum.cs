using System;

namespace _09.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            int index = 0;
            int len = 0;
            int maxSum = int.MinValue;
            
            for (int k = 1; k <= arr.Length; k++)
            {
                for (int x = 0; x < arr.Length - k; x++)
                {
                    int currSum = 0;

                    for (int i = x; i < x + k; i++)
                    {
                        currSum = currSum + arr[i];
                    }
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        index = x;
                        len = k;
                    }
                }
            }

            for (int i = index; i < index+len; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(maxSum );
        }
    }
}
