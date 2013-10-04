namespace _08.ReadNumber
{
    /* TODO: Напишете метод ReadNumber(int start, int end), който въвежда от конзолата 
       число в диапазона [start…end]. В случай на въведено невалидно число или 
       число, което не е в подадения диапазон хвърлете подходящо изключение. 
       Използвайки този метод напишете програма, която въвежда 10 числа 
       a1, a2, …, a10, такива, че 1 < a1 < … < a10 < 100.*/

    using System;

    public class ReadNum
    {
       public static void Main()
        {
            int ix = 0;
            int[] arr = new int[10];
            int start = 1;
            int end = 90;
            try
            {
                arr[ix++] = ReadNumber(1, 90);

                while (ix < 10)
                {
                    start = arr[ix - 1];
                    end = 90 + ix;
                    arr[ix] = ReadNumber(start, end);
                    ix++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "You have to enter a valid number between {0} and {1}",
                    start,
                    end);
            }
            catch (OverflowException)
            {
                Console.WriteLine(
                    @"The number you entered is too big. 
You have to enter a valid number between {0} and {1}.",
                    start,
                    end);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(
                    "The number must be between {0} and {1}.", 
                    start, 
                    end);
            }
        }

        private static int ReadNumber(int start, int end)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            if ((inputNumber < start) || (inputNumber > end))
            {
                string message = string.Format(
                    "The number must be between {0} and {1}.",
                    start,
                    end);
                throw new ArgumentOutOfRangeException("inputNumber", message); 
            }

            return inputNumber;
        }
    }
}
