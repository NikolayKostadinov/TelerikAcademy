using System;

class NumberSeries2
{
    static void Main()
    {
        double seriesMember = 2;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Member #{0} is: {1}", i+1, seriesMember);
            seriesMember = (Math.Abs(seriesMember) + 1) * Math.Pow(-1, i+1);
        }
    }
}

