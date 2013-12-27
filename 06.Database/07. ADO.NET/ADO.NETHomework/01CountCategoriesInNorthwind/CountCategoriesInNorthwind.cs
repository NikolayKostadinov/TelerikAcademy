namespace CountCategoriesInNorthwind
{
    using System;
    using System.Data.SqlClient;

    internal class CountCategoriesInNorthwind
    {
        private static void Main()
        {
            // TODO: Write a program that retrieves from the Northwind sample database in 
            // MS SQL Server the number of rows in the Categories table.

            string connectionString = Settings1.Default.NorthwindConnectionString; 
            SqlConnection northwindConnection = new SqlConnection(connectionString);
            string query = @"SELECT COUNT(*) FROM Categories";
            SqlCommand selectNumnerOfCategories = new SqlCommand(query, northwindConnection);
            northwindConnection.Open();

            using (northwindConnection) 
            {
                int numberOfRows = (int)selectNumnerOfCategories.ExecuteScalar();
                Console.WriteLine("Number Of Categories in NorthWind DataBase is: {0}", numberOfRows);
            }

            northwindConnection.Close();
        }
    }
}
