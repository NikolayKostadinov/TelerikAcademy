using System;

class NumberSeries
{
    static void Main(string[] args)
    {
        int seriesMember = 2;
       
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Memder #{0} is: {1}", i+1, seriesMember);
            seriesMember = seriesMember * -1;
            if (seriesMember>0)
            {
                seriesMember++;
            }
            else
            {
                seriesMember--;
            }
        }    
    }
}
