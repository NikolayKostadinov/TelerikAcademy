// IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

namespace ExpentionMethods
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableTExtentions
    {
        // implementing funtion Sum
        public static T Sum<T>(this IEnumerable<T> source) 
        {
            return source.Reduce((a, b) => a + b);
        }

        // implementing funtion product 
        public static T Product<T>(this IEnumerable<T> source)
        {
            return source.Reduce((a, b) => a * b);
        }

        // implementing funtion min
        public static T Min<T>(this IEnumerable<T> source)
        {
            return source.Reduce((a, b) => a < b ? a : b);
        }

        // implementing funtion max 
        public static T Max<T>(this IEnumerable<T> source)
        {
            return source.Reduce((a, b) => a > b ? a : b);
        }

        // implementing funtion average
        public static dynamic Average<T>(this IEnumerable<T> items)
        {
            return (dynamic)items.Sum() / items.Count();
        }

        private static int Count<T>(this IEnumerable<T> items)
        {
            return Convert.ToInt32(items.Reduce((a, _) => a + 1, 1));
        }

        private static T Reduce<T>(
            this IEnumerable<T> items, 
            Func<dynamic, T, T> func, 
            dynamic first = null)
        {
            IEnumerator<T> i = items.GetEnumerator();

            i.MoveNext();
            T previous = first ?? i.Current;

            while (i.MoveNext())
            {
                previous = func(i.Current, previous);
            }

            return previous;
        }
    }
}
