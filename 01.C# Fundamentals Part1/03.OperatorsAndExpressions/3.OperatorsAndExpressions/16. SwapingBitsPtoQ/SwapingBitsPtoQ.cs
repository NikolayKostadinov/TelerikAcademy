using System;


class SwapingBitsPtoQ
{
    static void Main(string[] args)
    {
        int inputNumber = 0;
        int p = 0;
        int q = 0;
        int k = 0;
        int maskedPositions=0;
        int maskP = 0;
        int maskQ = 0;

        Console.Write("Enter an integer number: ");
        inputNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter position p: ");
        p = int.Parse(Console.ReadLine());
        Console.Write("Enter q: ");
        q = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        k = int.Parse(Console.ReadLine());

        for (int i = 0; i < k; i++)
        {
            maskedPositions = maskedPositions | (1 << i);
        }

        maskP = maskedPositions  << p;
        maskQ = maskedPositions << q;
        
        maskP = (inputNumber & maskP) >> p;
        maskQ = (inputNumber & maskQ) >> q;
        Console.WriteLine("The number before swapping is:  {0}",
            Convert.ToString(inputNumber, 2).PadLeft(32, '0'));
        // muving bit3,bit4 and bit5 to bit24, bit25 and bit26
        for (int i = q; i < q+k; i++)
        {
            if (maskP % 2 == 1)
            {
                inputNumber = inputNumber | (1 << i);
            }
            else
            {
                inputNumber = inputNumber & (~(1 << i));
            }
            maskP >>= 1;
        }
        // muving bit24, bit25 and bit26 to bit3, bit4 and bit5
        for (int i = p; i < p+k; i++)
        {
            if (maskQ % 2 == 1)
            {
                inputNumber = inputNumber | (1 << i);
            }
            else
            {
                inputNumber = inputNumber & (~(1 << i));
            }
            maskQ >>= 1;
        }
        Console.WriteLine("The number after swapping is :  {0}",
            Convert.ToString(inputNumber, 2).PadLeft(32, '0'));
    }
}

