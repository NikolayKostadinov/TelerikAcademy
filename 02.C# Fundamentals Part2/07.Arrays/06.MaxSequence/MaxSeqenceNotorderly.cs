using System;
using System.Collections.Generic; 

namespace _07MaxSequenceNotorderly
{
    class MaxIncreasingSequence
    {
        static void Main()
        {
            int[] arr = { 9, 6, 2, 7, 4, 7, 5, 6, 7, 8, 4 };
            int[] len = new int[arr.Length];
            List<int> result = new List<int>(0);

            len[0] = 1;
            int index = 0; // В тази променлива ще запазим индекса на последния елемент на най-голямата последователност
            for (int x = 0; x < arr.Length; x++)
            {
                len[x] = 1;
                for (int i = 0; i < x; i++)
                {
                    if (arr[i] < arr[x] && len[i] + 1 > len[x]) // Правим проверка за по малък елемент
                    {
                        len[x] = len[i] + 1;
                    }
                }
                if (len[x] > len[index])
                {
                    index = x;
                }
            }

            Console.WriteLine("Longest sequence:"); // печатим редицата

            int prevIndex = index;            // Започваме от индекса на най-големия елемент
            result.Add(arr[index]);  // Добавяме най-големия елемент

            // Вървим назад по елементите и печатим по-малките
            for (; index >= 0; index--)
            {
                if (arr[index] < arr[prevIndex] && len[prevIndex] == len[index] + 1)  // Проверяваме дали има по-малък елемент от последния намерен и дали дължните на последователностите съвпадат
                {
                    result.Add (arr[index]);
                    prevIndex = index;  // Записваме индекса на новия последен елемент
                }
            }
            
            result.Sort();
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
