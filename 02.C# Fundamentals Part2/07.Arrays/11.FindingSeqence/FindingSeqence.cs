using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.FindingSeqence
{
    class FindingSeqence
    {
        static void Main()
        {
            int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
            int index = 0;
            int len = 0;
            int targetSum = int.Parse(Console.ReadLine());

            for (int k = 1; k <= arr.Length; k++)
            {
                for (int x = 0; x < arr.Length - k; x++)
                {
                    int currSum = 0;

                    for (int i = x; i < x + k; i++)
                    {
                        currSum = currSum + arr[i];
                    }
                    if (currSum == targetSum )
                    {
                        index = x;
                        len = k;
                        break;
                    }
                }
            }

            for (int i = index; i < index + len; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
