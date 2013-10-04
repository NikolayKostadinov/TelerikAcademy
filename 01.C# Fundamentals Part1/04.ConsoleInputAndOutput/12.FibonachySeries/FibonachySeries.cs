using System;

class FibonachySeries
{
    static void Main()
    {
        ulong tempPreviouser = 0l;
        ulong tempPrevious = 1l;
        ulong lastNumber = 0l;

        Console.WriteLine("member {0,3} is: {1,20:D}", 1, tempPreviouser);
        Console.WriteLine("member {0,3} is: {1,20:D}", 2, tempPrevious);

        for (int i = 2; i < 100; i++)
        {
            lastNumber = tempPreviouser + tempPrevious;
            tempPreviouser = tempPrevious;
            tempPrevious = lastNumber;
            Console.WriteLine("member {0,3} is: {1,20:D}",i+1, lastNumber);
        }
    }

}

