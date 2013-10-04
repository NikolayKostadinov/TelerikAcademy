using System;

public class BinarySearch
{
    public static void Main(string[] args)
    {
        int[] arr = new int[100];

        for (int i = 0; i < 100; i++)
        {
            arr[i] = i;
        }

        DateTime begin, end;
        while (true)
        {
            int number = int.Parse(Console.ReadLine());
            begin = DateTime.Now;
            int position = BinarySearch1(number, arr);
            end = DateTime.Now;
            Console.WriteLine(position > -1 ? position.ToString() : ("There is no " + number + " in the array!"));
            Console.WriteLine(end - begin);   
        }
    }
  
    private static int BinarySearch1(int number, int[] arr)
    {
        // If next statement is true then number is outside array
        if ((number < arr[0]) || (number > arr[arr.Length - 1]))
        {
            return -1;
        }

        // if there is possibility to find number start algorithm
        int index = -1;
        int leftBorder = 0;
        int righrBorder = arr.Length - 1;
        int mediana = arr.Length / 2;

        while (righrBorder - leftBorder > 1)
        {
            if (number == arr[mediana])
            {
                index = mediana;
                break;
            }
            else if (number > arr[mediana])
            {
                leftBorder = mediana;
            }
            else
            {
                righrBorder = mediana;
            }

            mediana = (righrBorder + leftBorder) / 2;
        }

        if (number == arr[leftBorder])
        { 
            index = leftBorder; 
        }
        else if (number == arr[righrBorder])
        {
            index = righrBorder;
        }

        return index;
    }
}
