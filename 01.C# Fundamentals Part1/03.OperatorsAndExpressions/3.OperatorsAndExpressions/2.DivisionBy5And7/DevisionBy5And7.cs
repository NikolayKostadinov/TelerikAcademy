using System;
class DevisionBy5And7
{
    static void Main()
    {
        int inputArgument = 0;
        bool result = false;
        Console.Write("Enter an integer number: ");
        try
        {
            inputArgument = int.Parse(Console.ReadLine());
            result = (inputArgument % 5 == 0) && (inputArgument % 7 == 0);
            if (result)
            {
                //The digit is divisible by 7 and 5
                Console.WriteLine("The number {0} is divisible by 7 and 5 without a remainder!", inputArgument);
            }
            else
            {
                //The digit isn't divisible by 7 and 5
                Console.WriteLine("The number {0} isn't divisible by 7 and 5!", inputArgument);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("You enter an invalid integer number!");
        }

    }
}

