using System;
using InputFunction;

// TODO: 10. Напишете програма, която прилага бонус точки към дадени точки в
//интервала [1..9] чрез прилагане на следните правила:
//- Ако точките са между 1 и 3, програмата ги умножава по 10.
//- Ако точките са между 4 и 6, ги умножава по 100.
//- Ако точките са между 7 и 9, ги умножава по 1000.
//- Ако точките са 0 или повече от 9, се отпечатва съобщение за
//грешка.

class BonusPoints
{
    static void Main()
    {
        try
        {
            int inputNumber = ConsoleInput.GetIntFromConsole("Enter the points: ");
            if ((inputNumber > 0) &&
                (inputNumber < 10))
            {
                switch (inputNumber)
                {
                    case 1:
                    case 2:
                    case 3:
                        inputNumber = inputNumber * 10;
                        break;
                    
                    case 4:
                    case 5:
                    case 6:
                        inputNumber = inputNumber * 100;
                        break;
                    
                    default:
                        inputNumber = inputNumber * 1000;
                        break;
                }

                Console.WriteLine("The point bonus is {0}.",inputNumber);
            }
            else
            {
                throw new Exception("The points must be between 1 and 9 ! ! !");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

