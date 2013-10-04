using System;
using System.Threading;
using InputFunction;

// 05. Напишете програма, която за дадена цифра (0-9), зададена като вход, извежда името на цифрата на български език.

    class NamingDigits
    {
        static void Main(string[] args)
        {
            int inputNumber = 0;
            do
            {
                try
                {
                    inputNumber = ConsoleInput.GetIntFromConsole("Enter a numer between 0-9: ");  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    inputNumber = 10;
                }
                if (inputNumber > 9) 
                {
                    Console.WriteLine("The number must be between 0-9!!!");
                    Thread.Sleep(1500);
                    Console.Clear();
                } 
            } while (inputNumber > 9);

            string numberName = "";
            switch (inputNumber)
            {
                case 0:
                    numberName = "Zero";
                    break;
                case 1:
                    numberName = "One";
                    break;
                case 2:
                    numberName = "Two";
                    break;
                case 3:
                    numberName = "Three";
                    break;
                case 4:
                    numberName = "Four";
                    break;
                case 5:
                    numberName = "Five";
                    break;
                case 6:
                    numberName = "Six";
                    break;
                case 7:
                    numberName = "Seven";
                    break;
                case 8:
                    numberName = "Eight";
                    break;
                default:
                    numberName = "Nine";
                    break;
            }

            Console.WriteLine("The number you entered was \" {0} \" !",numberName);
        }
    }
