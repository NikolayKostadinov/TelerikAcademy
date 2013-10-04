using System;

//1. Да се напише if-конструкция, която проверява стойността на две целочислени променливи и разменя техните стойности, 
//ако стойността на първата променлива е по-голяма от втората.

class SwapTheNumbers
{
    static void Main(string[] args)
    {
        int firstNumber = 20;
        int secondNumber = 5;
        int bufferNumber = 0;

        Console.WriteLine("Before checking the value of first variable is {0} and the value of the second variable is {1}.", firstNumber, secondNumber);

        if (firstNumber > secondNumber)
        {
            bufferNumber = secondNumber;
            secondNumber = firstNumber;
            firstNumber = bufferNumber;            
        }

        Console.WriteLine("After checking the value of first variable is {0} and the value of the second variable is {1}.", firstNumber, secondNumber);
    }
}

