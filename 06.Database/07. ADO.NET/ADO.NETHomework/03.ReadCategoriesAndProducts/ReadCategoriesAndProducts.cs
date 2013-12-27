namespace ReadCategoriesAndProducts
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    class ReadCategoriesAndProducts
    {
        private static void Main()
        {
            // TODO: Write a program that retrieves from the Northwind database 
            // all product categories and the names of the products in each category. 
            // Can you do this with a single SQL query (with table join)?


            string connectionString = Settings1.Default.NorthwindConnectionString;
            SqlConnection northwindConnection = new SqlConnection(connectionString);
            string query = 
                            @"SELECT cat.CategoryName, pr.ProductName
                            FROM Categories AS cat
	                            INNER JOIN Products AS pr
	                            ON pr.CategoryID = cat.CategoryID";

            SqlCommand selectNumnerOfCategories = new SqlCommand(query, northwindConnection);
            northwindConnection.Open();

            using (northwindConnection)
            {
                var dataReader = selectNumnerOfCategories.ExecuteReader();
                int ix = 0;
                while (dataReader.Read())
                {
                    ix++;

                    Console.WriteLine(" {0,3} | {1,-15} | {2,-50}", ix, dataReader[0], dataReader[1]);
                }
            }

            northwindConnection.Close();
        }
    }
}
