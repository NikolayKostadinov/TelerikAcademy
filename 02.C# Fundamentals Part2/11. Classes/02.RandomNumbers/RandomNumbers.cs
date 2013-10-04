namespace _02.RandomNumbers
{
    using System;

    public class RandomNumbers
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                RandomGenerator number = new RandomGenerator();
                Console.WriteLine(number);
            }
        }
    }
}
