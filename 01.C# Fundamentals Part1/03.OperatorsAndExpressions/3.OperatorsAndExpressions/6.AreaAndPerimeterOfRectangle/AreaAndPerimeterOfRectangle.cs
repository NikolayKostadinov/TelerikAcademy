using System;
using System.Threading;
using System.Globalization;
    class AreaAndPerimeterOfRectangle
    {
        static void Main()
        {
            //Cultural invariant console
            Thread.CurrentThread.CurrentCulture = 
                CultureInfo.InvariantCulture;

            double a = 0.0;
            double b = 0.0;
            double rectangleArea = 0.0;
            double rectanglePrimeter = 0.0;
            try
            {
                Console.Write("Enter a side: ");
                a = float.Parse(Console.ReadLine());
                Console.Write("Enter b side: ");
                b = float.Parse(Console.ReadLine());

                rectanglePrimeter = (a+b)*2;
                rectangleArea = a * b;
                Console.WriteLine("The perimeter of rectangle is {0:F2} .",rectanglePrimeter);
                Console.WriteLine("The area of rectangle is {0:F2} .",rectangleArea);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }

