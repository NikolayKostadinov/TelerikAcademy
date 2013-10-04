using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main()
        {

            int?[] arr = {0,0,0,0,0,0,0,0,0,0,0,0,0 };
            DateTime begin = DateTime.Now;

            //variant 1 Faster

            int maxCounter = 1;
            int? mostFrequentNum = null;

            for (int i = 0; i < arr.Length; i++)
            {
                int currCounter = 1;

                if (arr[i] != null)
                {
                    int? currNum = arr[i];
                    arr[i] = null;
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == currNum)
                        {
                            currCounter++;
                            arr[j] = null;
                        }
                    }
                    if (currCounter > maxCounter)
                    {
                        maxCounter = currCounter;
                        mostFrequentNum = currNum;
                    }
                }
            }

            //// vatiant 2

            //int mostFrequentNum = 1;
            //int maxNumberCount = 1;
            //Array.Sort(arr);
            //int currNum = arr[0];

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    int currNumCount = 0;

            //    if (arr[i] == currNum)
            //    {
            //        currNumCount++;

            //        if (currNumCount > maxNumberCount)
            //        {
            //            maxNumberCount = currNumCount;
            //            mostFrequentNum = currNum;
            //        }
            //    }
            //    else
            //    {
            //        currNum = arr[i];
            //        currNumCount = 1;
            //    }
            //}

            Console.WriteLine(mostFrequentNum);

            DateTime end = DateTime.Now;
            Console.WriteLine(end - begin);
        }
    }
}
