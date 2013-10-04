using System;


class CheckTheThirdBit
{
    static void Main()
    {
        int inputArgument = 0;
        int mask = 4;
        int result = 0;
        string binaryRepresentation = "";

        try
        {
            inputArgument = int.Parse(Console.ReadLine());
            binaryRepresentation = Convert.ToString(inputArgument, 2).PadLeft(32,'0');
            Console.WriteLine("The number you've entered is {0} and has binary representation {1} .", 
                inputArgument, binaryRepresentation);
            
            result = inputArgument & mask;

            
            if (result == 1)
            {
                Console.WriteLine("The third bit of number {0} is 1.",binaryRepresentation);
            }
            else
            {
                Console.WriteLine("The third bit of number {0} not 1.",binaryRepresentation);
            }

        }
        catch (FormatException)
        {
            Console.WriteLine("You enter an invalid integer number!");
        }
    }
}

