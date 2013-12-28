namespace SelectOrderWithSQLQuery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindModel;

    internal class Result 
    { 
        public string ContactName {get;set;}
        public string CompanyName {get;set;}
    }

    class SelectOrderWithSQLQuery
    {
        static void Main()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                int year = 1997;
                string country = "Canada";
                object[] parameters = {year, country};

                string queryString = @"SELECT DISTINCT cust.ContactName AS [ContactName], 
				                                       cust.CompanyName AS [CompanyName]
                                         FROM Orders AS ord
                                   INNER JOIN Customers AS cust 
                                           ON ord.CustomerID = cust.CustomerID
                                        WHERE YEAR(ord.OrderDate) = {0} AND 
                                              cust.Country = {1}";
              
                
        Type outputType = typeof(Result);
                
                var customers = db.Database.SqlQuery(outputType, queryString, parameters);

                foreach (Result item in customers)
                {
                    Console.WriteLine("{0,-30} | {1,-30}", item.CompanyName, item.ContactName);
                }
            }
        }
    }
}
