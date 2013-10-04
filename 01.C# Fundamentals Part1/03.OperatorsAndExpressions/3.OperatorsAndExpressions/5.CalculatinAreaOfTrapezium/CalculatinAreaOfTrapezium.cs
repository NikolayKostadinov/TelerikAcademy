using System;
using System.Threading;
using System.Globalization;

    class CalculatinAreaOfTrapezium
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = 
                CultureInfo.InvariantCulture;
            float a = 0.0f;
            float b = 0.0f;
            float h = 0.0f;
            float s = 0.0f;
            try
            {
                Console.Write("Enter a side: ");
                a = float.Parse(Console.ReadLine());
                Console.Write("Enter b side: ");
                b = float.Parse(Console.ReadLine());
                Console.Write("Enter h: ");
                h = float.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            s = ((a + b) / 2) * h;
            Console.WriteLine("The area of trapezium is {0:F2} .",s);
            }
    }

