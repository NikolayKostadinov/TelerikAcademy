using System;

    class SumOfFiveDigit
    {
        static void Main(string[] args)
        {
            bool isParseTrue = false;
            bool writeFlag = true; 
            int inputNumber = 0;
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                do
                {
                    Console.Write("Please enter an integer nubber {0}: ", i+1);
                    isParseTrue = int.TryParse(Console.ReadLine(), out inputNumber);

                    if (!isParseTrue)
                    {
                        Console.WriteLine("Please enter a valid number!");
                    }

                } while (!isParseTrue);

                try
                {
                    checked
                    {
                        sum += inputNumber;
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("The sum is too big.");
                    writeFlag = false;
                    break;
                }
            }
            
            if (writeFlag)
            {
                Console.WriteLine("The sum ot five numbers is {0}.", sum);   
            }
        }
    }
