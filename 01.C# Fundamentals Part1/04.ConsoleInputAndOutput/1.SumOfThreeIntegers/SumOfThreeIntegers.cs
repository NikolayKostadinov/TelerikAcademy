using System;

class SumOfThreeIntegers
{
    static void Main()
    {
        int firstNumber = 0;
        int secondNumber = 0;
        int thirdNumber = 0;
        int result = 0;

        try
        {
            Console.Write("Enter the first number: ");
            firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number: ");
            thirdNumber = int.Parse(Console.ReadLine());

            checked
            {
                result = firstNumber + secondNumber + thirdNumber;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        Console.WriteLine("The result of {0} + {1} + {2} = {3}", 
            firstNumber, secondNumber, thirdNumber, result);
    }
}

