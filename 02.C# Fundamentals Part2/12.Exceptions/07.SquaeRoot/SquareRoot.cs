namespace _07.SquaeRoot
{
    using System;

    /* TODO: Напишете програма, която прочита от конзолата цяло положително число 
       и отпечатва на конзолата корен квадратен от това число. 
       Ако числото е отрицателно или невалидно, да се изпише "Invalid Number" на 
       конзолата. Във всички случаи да се принтира на конзолата "Good Bye".*/

   public class SquareRoot
    {
        public static void Main()
        {
            int inputNumber = 0;
            try
            {
                inputNumber = ReadNumberFromConsole();
                Console.WriteLine("{0:F3}", CalculateSquareRoot(inputNumber));
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Invalid Number");  
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Invalid Number");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Number");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Invalid Number");
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }
        }

        private static double CalculateSquareRoot(int number)
        {
            double result = 0;
            result = Math.Sqrt(number); 
            return result;
        }

        private static int ReadNumberFromConsole()
        {
            int number = 0;
            number = int.Parse(Console.ReadLine());
            if (number < 0) 
            { 
                throw new ArgumentOutOfRangeException("Input number must be positive!"); 
            }

            return number;
        }
    }
}
