namespace ArticlesInGivenPriceRange
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    class ArticlesInGivenPriceRange
    {
        static void Main()
        {
            const bool areDublicationOfValuesAllawed = true;

            OrderedMultiDictionary<decimal, Articule> articules =
                new OrderedMultiDictionary<decimal, Articule>(areDublicationOfValuesAllawed);

            PopulateArticules(articules);
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = articules.Range(200m, true, 220m, true);
            sw.Stop();
            

            foreach (var record in result)
            {
                Console.BufferWidth = 160;
                foreach (var value in record.Value) 
                {
                    Console.WriteLine(value);
                }
            }

            Console.WriteLine("Elapsed time to find: {0}", sw.Elapsed);
        }

        private static void PopulateArticules(OrderedMultiDictionary<decimal, Articule> articules)
        {
            Random random = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                Articule articule = new Articule(
                    ("vendor " + i / 1000),
                    ("product" + i),
                    (decimal)random.Next(1, 200000) + (decimal)random.Next(1, 100) / 100m);
                articules.Add(articule.Price, articule);
            }
        }
    }
}
