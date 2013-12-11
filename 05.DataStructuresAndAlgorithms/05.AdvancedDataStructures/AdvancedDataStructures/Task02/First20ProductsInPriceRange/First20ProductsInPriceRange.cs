/* Write a program to read a large collection of products (name + price) 
 * and efficiently find the first 20 products in the price range [a…b]. 
 * Test for 500 000 products and 10 000 price searches.
        
 * Hint: you may use OrderedBag<T> and sub-ranges.
 */

namespace First20ProductsInPriceRange
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using Wintellect.PowerCollections;

    internal class First20ProductsInPriceRange
    {
        private static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();
            PopulateProducts(products);
            Product[] first20Products = new Product[20];

            int testsCount = 10000;
            StringBuilder testResults = new StringBuilder();

            Stopwatch sw = new Stopwatch();

            var totalElapsedTime = new TimeSpan();

            for (int test = 0; test < testsCount; test++)
            {
                sw.Start();

                try
                {
                    first20Products = First20ProductsInInterval(test, test+1, products);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (first20Products.Length == 0)
                {
                    Console.WriteLine("No result found for the searched criteria!!!");
                }

                sw.Stop();
                totalElapsedTime += sw.Elapsed;
                testResults.AppendLine(sw.Elapsed.ToString());
                sw.Reset();
            }


            foreach (var product in first20Products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine(testResults);
            Console.WriteLine("Total Elapsed Time: {0}", totalElapsedTime);
            Console.WriteLine("Average Elapsed Time: {0}", TimeSpan.FromTicks(totalElapsedTime.Ticks / testsCount));
        }

        private static Product[] First20ProductsInInterval(decimal minPrice, decimal maxPrice, OrderedBag<Product> products)
        {
            if (minPrice > maxPrice)
            {
                throw new ArgumentException("Maximal price must be greater or equal than minimal price!");
            }

            GenerateExceptionIfValueLessThanZero(minPrice, "minPrice");
            GenerateExceptionIfValueLessThanZero(maxPrice, "maxPrice");

            OrderedBag<Product>.View productsInRange =
                products.Range(
                new Product("testerMin", minPrice),
                true,
                new Product("testerMin", maxPrice),
                true);

            if (productsInRange.Count == 0) 
            {
                return new Product[0];
            }

            int selectedItemsLen = (20 > productsInRange.Count) ? productsInRange.Count : 20;  
            Product[] selectedItems = new Product[selectedItemsLen];

            for (int i = 0; i < selectedItemsLen; i++)
            {
                selectedItems[i] = productsInRange[i];
            }

            return selectedItems;
        }

        private static void GenerateExceptionIfValueLessThanZero(decimal value, string sender)
        {
            if (value.CompareTo(0) < 0)
            {
                throw new ArgumentException(sender + " must be greater than zero!");
            }
        }

        private static void PopulateProducts(OrderedBag<Product> products)
        {
            Random randomGenerator = new Random();

            for (int counter = 0; counter < 500000; counter++)
            {
                products.Add(
                    new Product(string.Format("Product {0}", counter),
                        (decimal)randomGenerator.Next(0, 10000) + (decimal)(randomGenerator.Next(1, 100)/100f)));
            }
        }
    }
}
