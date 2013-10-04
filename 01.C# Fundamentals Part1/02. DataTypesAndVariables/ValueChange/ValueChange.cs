using System;

class ValueChange
{
    static void Main()
    {
        int firstNumber = 5;
        int secontNumber = 10;
        int buffer = 0;
        Console.WriteLine("firstNumber is {0} and secondNumber is {1}", firstNumber,secontNumber);
        buffer = secontNumber;
        secontNumber = firstNumber;
        firstNumber = buffer;
        Console.WriteLine("Now the numbers were swapped: firstNumber is {0} and secondNumber is {1}", firstNumber,secontNumber);
    }
}

