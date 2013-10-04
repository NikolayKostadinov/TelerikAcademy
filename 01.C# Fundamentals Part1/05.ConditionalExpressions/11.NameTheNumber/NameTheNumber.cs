using System;
using InputFunction; 

// TODO: 11. * Напишете програма, която преобразува дадено число в интервала
//[0..999] в текст, съответстващ на българското произношение на
//числото. Примери:
//- 0 → "Нула"
//- 12 → "Дванадесет"
//- 98 → "Деветдесет и осем"
//- 273 → "Двеста седемдесет и три"
//- 400 → "Четиристотин"
//- 501 → "Петстотин и едно"
//- 711 → "Седемстотин и единадесет"


class NameTheNumber
{
    static void Main()
    {
        int number = 0;
        string nameOfNumber = "";
        bool flag = false;
        while (!flag)
        {
            nameOfNumber = "";
            try
            {
                number = ConsoleInput.GetIntFromConsole("Enter a number between 0 and 999: ");
                if ((number < 0) ||
                    (number > 999))
                {
                    throw new Exception("The number must be between 0 and 999 ! ! !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            int hundreds = number / 100;
            int decimals = (number % 100) / 10;

            if (hundreds > 0)
            {
                nameOfNumber += TranslateUnitsDigit(hundreds) + "hundred ";
            }

            if (decimals > 1)
            {
                nameOfNumber += TranslateDecimalsDigit(decimals);
                
                if ((number % 10) > 0)
                {
                    nameOfNumber += TranslateUnitsDigit(number % 10);
                }
            }
            else
            {
                if ((decimals % 10 ) > 0)
                {
                    nameOfNumber += " and " + TranslateUnitsDigit(number % 10);
                }
                else if (number == 0)
                {
                    nameOfNumber += TranslateUnitsDigit(number);
                }
                else 
                {
                    nameOfNumber += TranslateUnitsDigit(number % 10);
                }

            }

            Console.WriteLine(nameOfNumber);
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                flag = true;
            }
        }
    }

    static string TranslateUnitsDigit(int i)
    {
        string number = "";
        
        switch (i)
        {
            case 0:
                number = "zero";
                break;
            case 1:
                number = "one";
                break;
            case 2:
                number = "two";
                break;
            case 3:
                number = "three";
                break;
            case 4:
                number = "four";
                break;
            case 5:
                number = "five";
                break;
            case 6:
                number = "six";
                break;
            case 7:
                number = "seven";
                break;
            case 8:
                number = "eight";
                break;
            case 9:
                number = "nine";
                break;
            case 10:
                number = "ten";
                break;
            case 11:
                number = "eleven";
                break;
            case 12:
                number = "twelve";
                break;
            case 13:
                number = "thirteen";
                break;
            case 14:
                number = "fourteen";
                break;
            case 15:
                number = "fifteen";
                break;
            case 16:
                number = "sixteen";
                break;
            case 17:
                number = "seventeen";
                break;
            case 18:
                number = "eighteen";
                break;
            default:
                number = "nineteen";
                break;
        }
        
        return number; 
    }

    static string TranslateDecimalsDigit(int i)
    {
        string number = "";

        switch (i)
        {
            case 2:
                number = "twenty";
                break;
            case 3:
                number = "thirty";
                break;
            case 4:
                number = "fourty";
                break;
            case 5:
                number = "fifty";
                break;
            case 6:
                number = "sixty";
                break;
            case 7:
                number = "sevty";
                break;
            case 8:
                number = "eighty";
                break;
            default:
                number = "ninety";
                break;
        }

        return number;
    }
}

