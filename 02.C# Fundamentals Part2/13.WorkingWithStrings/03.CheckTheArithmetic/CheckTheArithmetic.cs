/* TODO: Напишете програма, която проверява дали 
 * в даден аритметичен израз скобите са поставени коректно. 
 * Пример за израз с коректно поставени скоби: ((a+b)/5-d). 
 * Пример за некоректен израз: )(a+b)).*/

namespace _03.CheckTheArithmetic
{
    using System;

    public class CheckTheArithmetic
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            bool isCorrect = CheckEquation(inputString);
            Console.WriteLine("The equation is {0}.", isCorrect ? "correct" : "incorrect");
        }

        private static bool CheckEquation(string inputString)
        {
            bool isCorrect = false;
            bool isOpen = false;
            int openCounter = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '(')
                {
                    isOpen = true;
                    isCorrect = true;
                    openCounter++;
                }
                else if (inputString[i] == ')')
                {
                    if (openCounter > 1)
                    {
                        openCounter--;
                    }
                    else if (openCounter == 1)
                    {
                        openCounter--;
                        isOpen = false;
                        isCorrect = true;
                    }
                    else if (openCounter < 1)
                    {
                        isOpen = false;
                        isCorrect = false;
                        return false;
                    }
                }
            }

            if (isOpen == false &&
                openCounter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
