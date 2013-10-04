using System;
using InputFunction;
using System.Threading;
using System.Globalization; 

// 06. Напишете програма, която при въвеждане на коефициентите (a, b и c) на квадратно уравнение: ax2+bx+c, 
// изчислява и извежда неговите реални корени (ако има такива). Квадратните уравнения могат да имат 0, 1 или 2 реални корена.

class SquareEquation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double a = 0.0f;
        double b = 0.0f;
        double c = 0.0f;
        double x1 = 0.0f;
        double x2 = 0.0f;
        double d = 0.0f;
        
        //read a,b,c

        try
        {
            while (a == 0.0)
            {
                a = ConsoleInput.GetDoubleFromConsole("Enter a: ");
                if (a == 0.0)
                {
                    Console.WriteLine("a must be different from 0!!!");
                }
            }

            b = ConsoleInput.GetDoubleFromConsole("Enter b: ");
            c = ConsoleInput.GetDoubleFromConsole("Enter c: ");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
            
        //Calculate D=-b^2-4a*c;
        d = (Math.Pow(b, 2))-(4*a*c);
        //incpecting D
        if (d >= 0)
        {
            x1 = (-b - Math.Sqrt(d)) / (2 * a);
            if (d > 0)
            {
                x2 = (-b + Math.Sqrt(d)) / (2 * a);
            }
            else
            {
                x2 = x1;
            }
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("The roots of equation " +
                (a != 1 ? a.ToString("F2") : "") + "x²" +
                (b > 0 ? "+" : "")
                + b.ToString("F2") + "x" +
                 (c > 0 ? "+" : "") +
                c.ToString("F2") + " is:");
            Console.WriteLine("x1 = {0:f2}", x1);
            Console.WriteLine("x2 = {0:f2}", x2);
        }
        else
        {
            Console.WriteLine("No real roots for this equation!");
        }
    }
}