using System;

    class ShowingBitOnPosition
{
    static void Main()
    {
        int inputNumber = 0;
        int position = 0;
        int mask = 0;
        int result = 0;
        try
        {
            Console.Write("Enter an integer number: ");
            inputNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter position: ");
            position = int.Parse(Console.ReadLine());
            if (!((position < 0) || (position > 31)))
            {
                mask = (int)Math.Pow(2, position);
                result = inputNumber & mask;
                result >>= position;
                Console.WriteLine("The bit {0} of entered number {1} is {2}.",
                    position, 
                    Convert.ToString(inputNumber, 2).PadLeft(32, '0'),
                    result);
                bool bRes = false;
                bRes = (inputNumber & (int)Math.Pow(2, position)) > 0;
                Console.WriteLine(bRes);
            }
            else
            {
                Console.WriteLine("The position must be between 0-31!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
