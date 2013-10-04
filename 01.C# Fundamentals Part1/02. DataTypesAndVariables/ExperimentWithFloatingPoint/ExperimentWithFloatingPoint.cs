using System;

class ExperimentWithFloatingPoint
{
    static void Main()
    {
        //Floating point aritmetic abnormalities
        double a = 1.0f;
        double b = 0.33f;
        double sum = 1.33f;
        bool equal = (a + b == sum); //Probably False!!!
        Console.WriteLine("a+b={0}  sum={1}  equal={2}",
            a+b,sum,equal);
    }
}
