using System;

class NumbersBetween
{
    static void Main()
    {
        //Напишете програма, която чете от конзолата две цели числа (int) и отпечатва, 
        //колко числа има между тях, такива, че остатъкът им от деленето на 5 да е 0. 
        //Пример: в интервала (17, 25) има 2 такива числа.
        int firstNumber = 0;
        int secondNumber = 0;
        int counter = 0;
        Console.Write("Enter first number: ");
        firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        secondNumber = int.Parse(Console.ReadLine());

        for (int i = firstNumber; i <= secondNumber ; i++)
        {
            if ((i % 5) == 0)
            {
                counter = counter + 1;
            }
        }

        Console.WriteLine("The count of numbers between {0} and {1} \n" + 
            "which are divisible by 5 without remainder is: {2}", firstNumber,secondNumber,counter);
    }
}
