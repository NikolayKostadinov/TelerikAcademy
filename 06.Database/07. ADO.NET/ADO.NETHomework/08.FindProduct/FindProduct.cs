namespace FindProduct
{
    using System;
    using System.Data.SqlClient;

    internal class FindProduct
    {
        private static void Main()
        {
            string connectionString = Settings1.Default.NorthwindConnectionString;
            SqlConnection conection = new SqlConnection(connectionString);

            conection.Open();

            string searchString = Console.ReadLine().Replace("%", "[%]")
                                                    .Replace("_", "[_]");

            using (conection)
            {
                SqlCommand command = new SqlCommand(@"
                                                    SELECT c.CategoryName, p.ProductName FROM Products p 
                                                            JOIN Categories c ON c.CategoryID = p.CategoryID
                                                    WHERE p.ProductName LIKE @searchString
                                                    ORDER BY c.CategoryName
                                                 ", conection);
                command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("All products in a category:");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string categoryDesc = (string)reader["ProductName"];

                        Console.WriteLine("Cat name: {0} | Product name: {1}", categoryName.PadRight(15), categoryDesc);
                    }
                }
            }
        }
    }
}
