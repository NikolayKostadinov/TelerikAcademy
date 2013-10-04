using System;
using InputFunction;

//2. Напишете програма, която показва знака (+ или -) от произведението на три реални числа, без да го пресмята. 
//   Използвайте последователност от if оператори.

class CalculateTheSignOfMultiplication
{
    static void Main(string[] args)
    {
        try
        {
            int firstNumber = ConsoleInput.GetIntFromConsole("Enter first number: ");
            int secondNumber = ConsoleInput.GetIntFromConsole("Enter second number: "); 
            int thirdNumber = ConsoleInput.GetIntFromConsole("Enter third number: ");

            if (((firstNumber > 0) && (secondNumber > 0) && (thirdNumber > 0))||
                ((firstNumber < 0) && (secondNumber < 0) && (thirdNumber > 0))||
                ((firstNumber < 0) && (secondNumber > 0) && (thirdNumber < 0)))
            { // result is positive
                Console.WriteLine("Result is positive.");
            }
            else
            { // result is negative
                Console.WriteLine("Result is negative.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

