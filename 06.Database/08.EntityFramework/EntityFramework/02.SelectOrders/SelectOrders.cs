namespace SelectOrders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NorthwindModel;


    class SelectOrders
    {
        // TODO: Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

        static void Main()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                DateTime dateStart = new DateTime(1997, 1, 1);
                DateTime dateEnd = new DateTime(1997, 12, 31); 

                var result = (from order in db.Orders
                             join customer in db.Customers on order.CustomerID equals customer.CustomerID
                             where (order.OrderDate >= dateStart && order.OrderDate <= dateEnd) && (customer.Country == "Canada")
                             select customer).Distinct();

                foreach (var customer in result)
                {
                    Console.WriteLine("{0,-30} | {1,-30}",customer.CompanyName, customer.ContactName);
                }
            }
        }
    }
}
