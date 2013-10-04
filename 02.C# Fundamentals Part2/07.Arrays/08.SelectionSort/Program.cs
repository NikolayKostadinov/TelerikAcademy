using System;

namespace _08.SelectionSort
{
    class Program
    {
        static void Main()
        {
            int[] arr = { 9, 8, 7, 6, 5, 4, 3, 2, 1};
            int index = 0;
            for (int x = 0; x < arr.Length; x++)
            {
                int currIndex = x + 1;
                int minimalMember = arr[x];
                for (; currIndex < arr.Length; currIndex++)
                {
                    if (minimalMember > arr[currIndex])
                    {
                        minimalMember = arr[currIndex];
                        index = currIndex; 
                    }
                }

                if (arr[x]>arr[index])
                {
                    int temp = arr[x];
                    arr[x] = arr[index];
                    arr[index] = temp;
                }

            }

            Console.WriteLine(string.Join(" ",arr));
        }
    }
}