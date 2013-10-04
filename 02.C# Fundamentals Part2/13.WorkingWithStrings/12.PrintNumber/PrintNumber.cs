/* TODO: Напишете програма, която чете число от конзолата и го отпечатва в 
 * 15-символно поле, подравнено вдясно по няколко начина: 
 * като десе-тично число, като шестнайсетично число, като процент, 
 * като валутна сума и във вид на експоненциален запис (scientific notation). */

namespace _12.PrintNumber
{
    using System;
    using System.IO;

    public class PrintNumber
    {
       public static void Main()
        {
            try
            {
                long number = long.Parse(Console.ReadLine());
                Console.WriteLine("{0,15:N}", number); // decimal number
                Console.WriteLine("{0,15:x}", number); // hexadecimal number
                Console.WriteLine("{0,15:P}", number / 100.00); // percent
                Console.WriteLine("{0,15:C}", number); // currency
                Console.WriteLine("{0,15:E}", number); // exponential record
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Not enough memory to complete operation!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
