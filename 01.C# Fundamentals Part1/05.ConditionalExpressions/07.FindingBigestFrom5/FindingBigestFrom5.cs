using System;
using InputFunction;

// 07. Напишете програма, която намира най-голямото по стойност число измежду дадени 5 числа.

class FindingBigestFrom5
{
    static void Main(string[] args)
    {
        int[] inNumbers = new int[5];

        for (int i = 0; i < inNumbers.Length; i++)
        {
            try
            {
                inNumbers[i] = ConsoleInput.GetIntFromConsole("Enter " + (i + 1) + " number: ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        int maxNumber = inNumbers[0];
        for (int i = 1; i < inNumbers.Length; i++)
        {
            if (maxNumber < inNumbers[i])
            {
                maxNumber = inNumbers[i];
            }
        }

        Console.WriteLine("The biggest number is {0}.", maxNumber);
    }
}

