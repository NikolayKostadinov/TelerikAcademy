using System;

    class WriteBigestNumber
    {
       
        static void Main(string[] args)
        {
            bool isParseTrue = false;
            int inputNumber = 0;
            int maxNumber = 0;

            do
            {
                Console.Write("Please enter an integer nubber {0}: ", 1);
                isParseTrue = int.TryParse(Console.ReadLine(), out inputNumber);

                if (!isParseTrue)
                {
                    Console.WriteLine("Please enter a valid number!");
                }

            } while (!isParseTrue);
            maxNumber = inputNumber;

            for (int i = 1; i < 5; i++)
            {
                do
                {
                    Console.Write("Please enter an integer nubber {0}: ", i + 1);
                    isParseTrue = int.TryParse(Console.ReadLine(), out inputNumber);

                    if (!isParseTrue)
                    {
                        Console.WriteLine("Please enter a valid number!");
                    }

                } while (!isParseTrue);

                if (maxNumber < inputNumber)
                {
                    maxNumber = inputNumber;
                }
            }

            Console.WriteLine("The biggest number of all entered is {0}.", maxNumber);
        }
}
