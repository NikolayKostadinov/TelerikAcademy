using System;

class BitSwaping
{
    static void Main()
    {
        int inputNumber = 0;
        int mask345 = 7 << 3;
        int mask242526 = 7 << 24;
 
        Console.Write("Enter an integer number: ");
        inputNumber = int.Parse(Console.ReadLine());
        //3, 4 и 5 с битовете на позиции 24, 25 и 26
        mask345 = (inputNumber & mask345)>>3;
        mask242526 = (inputNumber & mask242526)>>24;
        Console.WriteLine("The number before swapping is:  {0}",
            Convert.ToString(inputNumber,2).PadLeft(32,'0') );
        // muving bit3,bit4 and bit5 to bit24, bit25 and bit26
        for (int i = 24; i < 27; i++)
        {
            if (mask345 % 2 == 1)
            {
                inputNumber = inputNumber | (1 << i);
            }
            else
            {
                inputNumber = inputNumber & (~(1<<i));
            }
            mask345 >>= 1;
        }
        // muving bit24, bit25 and bit26 to bit3, bit4 and bit5
         for (int i = 3; i < 6; i++)
        {
            if (mask242526 % 2 == 1)
            {
                inputNumber = inputNumber | (1 << i);
            }
            else
            {
                inputNumber = inputNumber & (~(1<<i));
            }
            mask242526 >>= 1;
        }
         Console.WriteLine("The number after swapping is :  {0}",
             Convert.ToString(inputNumber, 2).PadLeft(32, '0'));
    }
}

