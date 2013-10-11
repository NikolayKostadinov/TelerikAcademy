namespace BitArray64Demo
{
    using System;
    using BitArray64;

    class Program
    {
        static void Main()
        {
            BitArray64 bitTester = new BitArray64 ("10101010101010101010");
            Console.WriteLine(bitTester);
            bitTester[4] = 1;
            Console.WriteLine(bitTester);

            BitArray64 bitTester1 = bitTester;
            Console.WriteLine("bitTester  => " + bitTester);
            Console.WriteLine("bitTester1 => " + bitTester1);
            Console.WriteLine("bitTester.Equals(bitTester1) => " + bitTester.Equals(bitTester1));
            Console.WriteLine("bitTester == bitTester1 => " + (bitTester == bitTester1));
            Console.WriteLine("bitTester1 != bitTester1 => " + (bitTester1 != bitTester1));
        }
    }
}
