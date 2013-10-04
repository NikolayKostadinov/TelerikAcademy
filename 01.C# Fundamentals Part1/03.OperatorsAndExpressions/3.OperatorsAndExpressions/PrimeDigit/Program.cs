using System;

    class Program
    {
        static void Main()
        {
            byte inputNumber = 0;
            byte loops = 0;
            Console.Write("Enter an nubet between 1 and 100: ");
            inputNumber = byte.Parse(Console.ReadLine());
            for (byte  i = 1; i <= 100; i++)
            {
                if ((inputNumber % i == 0) &&
                    (i != 1) &&
                    (i != inputNumber))
                {
                    break;
                }
                loops = i;
            }
            if ((loops == 100) && (inputNumber != 1))
            {
                Console.WriteLine("The number {0} is prime!!!", inputNumber);
            }
            else
            {
                Console.WriteLine("The number {0} isn't prime!!!", inputNumber);
            }
        }
    }