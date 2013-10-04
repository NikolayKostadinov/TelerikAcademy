// -----------------------------------------------------------------------
// <copyright file="RandomProvider.cs" company="">
// An singleton random numbers provider.
// </copyright>
// -----------------------------------------------------------------------

namespace _02.RandomNumbers
{
    using System;

    /// <summary>
    /// An singleton random numbers provider.
    /// </summary>
    public static class RandomProvider
    {
        private static readonly Random rnd = new Random();
        private static readonly object sync = new object();

        public static object Sync
        {
            get
            {
                return sync;
            }
        }

        public static Random Rnd
        {
            get
            {
                return rnd;
            }
        }

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