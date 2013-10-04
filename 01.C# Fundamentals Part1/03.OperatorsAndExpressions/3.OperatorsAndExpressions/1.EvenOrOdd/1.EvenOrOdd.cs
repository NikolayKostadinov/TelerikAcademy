using System;

    class EvenOrOdd
    {
        static void Main()
        {
            int inputArgument = 0;
            int result = 0;
            Console.Write("Enter an integer number: ");
            try
            {
                inputArgument = int.Parse(Console.ReadLine());
                result = inputArgument % 2;
                if (result == 0)
                {
                    //The digit is Even
                    Console.WriteLine("You entered an even number!");
                }
                else
                {
                    //The digit is Odd
                    Console.WriteLine("You entered an odd number!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You enter an invalid integer number!");
            }
            
        }
    }

