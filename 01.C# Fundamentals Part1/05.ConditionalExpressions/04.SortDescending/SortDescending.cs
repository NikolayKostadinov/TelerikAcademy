using System;
using System.Threading;
using System.Globalization;
using InputFunction; 

//4. Сортирайте 3 реални числа в намаляващ ред. Използвайте вложени if оператори.

class SortDescending
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
  
            float[] inNumber = new float[3];

        for (int i = 0; i < inNumber.Length ; i++)
        {
            try
            {
                inNumber[i] = ConsoleInput.GetfloatFromConsole("Enter " + (i + 1) + " number: ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        
        /*Buble sort*/
        for (int i = 0; i < inNumber.Length ; ++i)
            for (int j = inNumber.Length - 1; j > i; --j)
            {

                /*Сравняване на съседни елементи*/
                if (inNumber[j - 1] < inNumber[j])
                {
                    float temp = inNumber[j - 1]; 
                    inNumber[j - 1] = inNumber[j];
                    inNumber[j] = temp;
                }
            }

        // Printing
        for (int i = 0; i < inNumber.Length; i++)
        {
            Console.WriteLine("inNumber {0} = {1,10:F2}",i, inNumber[i]);
        }

    }
}

