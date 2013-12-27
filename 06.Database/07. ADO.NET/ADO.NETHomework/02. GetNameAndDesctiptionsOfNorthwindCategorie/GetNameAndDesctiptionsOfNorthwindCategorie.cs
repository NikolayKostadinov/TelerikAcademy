namespace GetNameAndDesctiptionsOfNorthwindCategorie
{
    using System;
    using System.Data.SqlClient;

    internal class GetNameAndDesctiptionsOfNorthwindCategorie
    {
        private static void Main()
        {
            // TODO: Write a program that retrieves 
            // the name and description of all categories in the Northwind DB.

            string connectionString = Settings1.Default.NorthwindConnectionString;
            SqlConnection northwindConnection = new SqlConnection(connectionString);
            string query = @"SELECT CategoryName, Description FROM Categories";
            SqlCommand selectNumnerOfCategories = new SqlCommand(query, northwindConnection);
            northwindConnection.Open();

            using (northwindConnection)
            {
                var dataReader = selectNumnerOfCategories.ExecuteReader();
                int ix = 0;
                while (dataReader.Read())
                {
                    ix++;

                    Console.WriteLine("{0,3}|{1,15}|{2,59}", ix, dataReader[0], dataReader[1] ?? String.Empty);
                }
            }

            northwindConnection.Close();
        }
    }
}
