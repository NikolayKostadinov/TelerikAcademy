using System;

    class CompareTwoNumbers
    {
        static void Main()
        {
            bool isParseTrue = false;
            int firstNumber = 0;
            int secondNumber = 0;
            int greaterNumber = 0;
            int lowerNumber = 0;

            Console.Clear();
            do
            {
                Console.Write("Please enter an integer nubber a: ");
                isParseTrue = int.TryParse(Console.ReadLine(), out firstNumber);
                
                if (!isParseTrue)
                {
                    Console.WriteLine("Please enter a valid number!");
                }

            } while (!isParseTrue);

            Console.Clear();
            do
            {
                Console.Write("Please enter an integer nubber b: ");
                isParseTrue = int.TryParse(Console.ReadLine(), out secondNumber);

                if (!isParseTrue)
                {
                    Console.WriteLine("Please enter a valid number!");
                }

            } while (!isParseTrue);

            greaterNumber = (firstNumber + secondNumber + Math.Abs(firstNumber - secondNumber)) / 2;
            lowerNumber = (firstNumber + secondNumber - Math.Abs(firstNumber - secondNumber)) / 2;
            
            Console.WriteLine("Greater Number is: {0}", greaterNumber);
            Console.WriteLine("Lower Number is: {0}", lowerNumber);
        }
    }
