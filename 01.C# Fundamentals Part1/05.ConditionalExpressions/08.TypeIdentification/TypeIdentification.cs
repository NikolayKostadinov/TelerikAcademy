using System;
using InputFunction;
using System.Threading;
using System.Globalization;

// 08. Напишете програма, която по избор на потребителя прочита от конзолата променлива от тип int, double или string. 
// Ако променливата е int или double, трябва да се увеличи с 1. Ако променливата е string, трябва да се прибави накрая символа "*". 
// Отпечатайте получения резултат на конзолата. Използвайте switch конструкция.

enum TypeInput {@int=1, @double=2, @string=3};

class TypeIdentification
{
    static void Main()
    {
        //Ignore regional settings
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;  
        
        TypeInput typeOfInput = (TypeInput)ConsoleInput.GetIntFromConsole("Enter the type of input value:\n 1. int;\n 2. double;\n 3. string\n : ");
        Console.WriteLine(typeOfInput);
        try
        {
            switch ((int)typeOfInput)
            {
                case 1:
                    int inputNumber = ConsoleInput.GetIntFromConsole("Enter a number: ");
                    Console.WriteLine("{0}: {1}", typeOfInput, inputNumber + 1);
                    break;
                case 2:
                    double inputDNumber = ConsoleInput.GetDoubleFromConsole("Enter a real number: ");
                    Console.WriteLine("{0}: {1}", typeOfInput, inputDNumber + 1.0);
                    break;
                case 3:
                    Console.Write("Enter a string: ");
                    string inputString = Console.ReadLine();
                    Console.WriteLine("{0}: {1}", typeOfInput, inputString + '*');
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}