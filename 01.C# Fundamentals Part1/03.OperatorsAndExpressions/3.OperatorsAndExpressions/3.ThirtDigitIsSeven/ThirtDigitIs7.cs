using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ThirdDigitIs7
{
    static void Main()
    {
        int inputArgument = 0;
        int bufferNumber = 0;
        bool result = false;
        Console.Write("Enter an integer number with less 3 digits: ");
        try
        {
            inputArgument = int.Parse(Console.ReadLine());
            bufferNumber = inputArgument / 100;
            bufferNumber %= 10;
            result = (bufferNumber == 7);
            if (result)
            {
                //The third digit is 7
                Console.WriteLine("Third digit of number {0} is 7 !!! ", inputArgument);
            }
            else
            {
                //The third digit isn't 7
                Console.WriteLine("Third digit of number {0} isn't 7 !!! ", inputArgument);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("You enter an invalid integer number!");
        }
        
    }
}


