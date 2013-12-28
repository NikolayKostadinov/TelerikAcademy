namespace SalesByRegionAndPeriod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindModel;

    class SalesByRegionAndPeriod
    {
        // TODO: Write a method that finds all the sales by specified region and period (start / end dates).

        static void Main()
        {
            using(NorthwindEntities db = new NorthwindEntities())
            {
                DateTime startDate = new DateTime(1997,01,01);
                    DateTime endDate = new DateTime(2001,12,31);
                string region = "ID";
                var orders = from ord in db.Orders
                             where ord.OrderDate >= startDate && ord.OrderDate <= endDate && ord.ShipRegion == region
                             select new { ord.OrderDate, ord.ShipRegion, ord.OrderID };

                foreach (var ord in orders)
                {
                    Console.WriteLine("{0,-30} | {1,-10} | {2,-20}", ord.OrderDate, ord.ShipRegion, ord.OrderID);
                }

            }
        }
    }
}
