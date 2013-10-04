namespace PasswordGenerator
{
    using System;

    public static class RandomProvider
    {
        private static Random rnd = new Random();
        private static object sync = new object();

        public static int Next()
        {
            lock (sync)
            {
                return rnd.Next();
            }
        }

        public static int Next(int max)
        {
            lock (sync)
            {
                return rnd.Next(max);
            }
        }

        public static int Next(int min, int max)
        {
            lock (sync)
            {
                return rnd.Next(min, max);
            }
        }
    }
}
