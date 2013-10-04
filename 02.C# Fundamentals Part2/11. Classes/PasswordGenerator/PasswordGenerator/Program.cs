namespace PasswordGenerator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            PasswordGenerator password = new PasswordGenerator(12);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(password.Generate());
            }
        }
    }
}
