using System;

class SetTheBit
{
    static void Main()
    {
        int inputNumber = 0;
        int position = 0;
        int newValueOfTheBit = 0;
        int result = 0;

        Console.Write("Enter an integer number: ");
        inputNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter position: ");
        position = int.Parse(Console.ReadLine());
        Console.Write("Enter new value for this bit (1/0): ");
        newValueOfTheBit = int.Parse(Console.ReadLine());

        if (newValueOfTheBit==1)
        {
            //set the bit 1 
            //  0000 1010 set bit5
            //  OR
            //  0001 0000 
            // __________
            //  0001 1010 -the rest bits are the same, bit5 is 
            //             set to 1 no mater what was previous condition

            result = inputNumber | (1 << position);
        }
        else
        {
           //reset the bit 0
            //set the bit 1 
            //  0001 1010 reset bit5
            //  and
            //  1110 1111 
            // __________
            //  0000 1010 - the rest bits are the same, bit5 is 
            //              reset to 0 no mater what was previous condition

            result = inputNumber & (~(1 << position));
        }

        Console.WriteLine("You entered:     {0,-32}",Convert.ToString(inputNumber,2).PadLeft(32,'0'));
        Console.WriteLine("The result is:   {0,-32}", Convert.ToString(result, 2).PadLeft(32, '0'));
    }
}

