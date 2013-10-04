using System;
//using System.Collections.Generic;

class MergeSort
{
    static void Main()
    {
        int[] arr = { 0, 2, 5, 1, 3, 4, 6 };

        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        //    178, 10, 6, 154, 162, 193, 74, 23, 39, 46, 86, 
        //    193, 36, 195, 163, 7, 138, 121, 27, 45, 186, 
        //    1, 178, 102, 45, 185, 114, 137, 90, 170, 175, 
        //    59, 0, 182, 185, 45, 33, 9, 18, 179, 110, 189, 
        //    10, 116, 160, 92, 49, 89, 136, 198, 98, 167, 
        //    139, 16, 14, 177, 31, 104, 109, 177, 79, 137, 
        //    133, 69, 70, 26, 193, 54, 9, 117, 174, 128,
        //    103, 47, 135, 197, 190, 61, 141, 152, 135, 
        //    25, 0, 91, 71, 8, 120, 184, 167, 8, 13, 128, 
        //    100, 40, 100, 173, 55, 141, 45, 133
        //}; 
        //new int[100];
        //Random generator = new Random();

        //for (int i = 0; i < arr.Length ; i++)
        //{
        //    arr[i] = generator.Next(200);
        //}
        int leftBorder1 = 0;
        int leftBorder2 = 0;
        int step = 1;
        int lastIndex = 0;
        while (step <= arr.Length / 2)
        {
            leftBorder2 = leftBorder1 + step;
            for (int i = 0; i < ((arr.Length) / 2) / step; i++)
            {
                MergeArray(leftBorder1, leftBorder1 + step - 1, leftBorder2, leftBorder2 + step - 1, arr);

                lastIndex = leftBorder2 + step - 1;
                leftBorder1 = leftBorder2 + step;
                leftBorder2 = leftBorder1 + step;

            }

            if (lastIndex < arr.Length - 1)
            {
                lastIndex++;
                MergeArray(lastIndex, lastIndex + step - 1, lastIndex + step, arr.Length - 1, arr);
            }
            step = step << 1;
            leftBorder1 = 0;

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        if (lastIndex < arr.Length - 1)
        {
            lastIndex--;
            MergeArray(0, lastIndex, lastIndex + 1, arr.Length - 1, arr);
        }

        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

    }
    


    private static void MergeArray(int leftBorder1, int rightBorder1, int leftBorder2, int rightBorder2, int[] arr)
    {
        int len = 0;
        bool firstIsBigger = false;
        int[] arrTemp = new int[rightBorder2 - leftBorder1 + 1];
        int delta = (rightBorder1 - leftBorder1) - (rightBorder2 - leftBorder2);
        if (delta < 0) 
        { 
            delta = -1 * delta; 
        }

        if (rightBorder1 - leftBorder1 < rightBorder2 - leftBorder2)
        {
            len = rightBorder1 - leftBorder1 + 1;
        }
        else 
        {
            len = rightBorder2-leftBorder2 + 1;
            firstIsBigger = true;
        }
        
        int ix = 0, j = 0, k = 0;
        while ((j < len)&&(k < len))
        {
            if (arr[leftBorder1 + j] > arr[leftBorder2 + k])
            {
                arrTemp[ix] = arr[leftBorder2 + j];
                j++;
            }
            else
            {
                arrTemp[ix] = arr[leftBorder1 + k];
                k++;
            }
            ix++;
        }

        if (ix < 2 * len) 
        {
            if (j < len)
            {
                for (; ix < arrTemp.Length; ix++)
                {
                    arrTemp[ix] = arr[leftBorder2 + j++];
                }
            }
            else
            {
                for (; ix < arrTemp.Length; ix++)
                {
                    arrTemp[ix] = arr[leftBorder2 + k++];
                }
            }
        }

        if (delta > 0)
        {
            if (firstIsBigger)
            {
                for (int i = 0; i < delta; i++)
                {
                    arrTemp[arrTemp.Length - delta + i] = arr[(leftBorder1 + len) + i];
                }
            }
            else 
            {
                for (int i = 0; i < delta; i++)
                {
                    arrTemp[arrTemp.Length - delta + i] = arr[(leftBorder2 + len) + i];
                }
            }
        }

        for (int i = 0; i < arrTemp.Length; i++)
        {
            arr[leftBorder1 + i] = arrTemp[i];
        }
    }
}
