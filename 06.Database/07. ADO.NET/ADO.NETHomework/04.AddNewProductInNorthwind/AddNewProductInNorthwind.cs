namespace AddNewProductInNorthwind
{
    using System;
    using System.Data.SqlClient;

    internal class Program
    {
        private static void Main()
        {
            // TODO: Write a method that adds a new product in the products table in the Northwind database. 
            // Use a parameterized SQL command.


            string connectionString = Settings1.Default.NorthwindConnectionString;
            SqlConnection northwindConnection = new SqlConnection(connectionString);
            string query = @"INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, 
                                    UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                             VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, 
                                        @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";

            SqlCommand createNewProduct = new SqlCommand(query, northwindConnection);
            FillProperties(createNewProduct, "Кифтета", false, 1, 2, "1 - 1 piece", 1.5m, 200, 20, 20);

            northwindConnection.Open();

            using (northwindConnection)
            {
                Console.WriteLine(createNewProduct.ExecuteNonQuery());
            }

            northwindConnection.Close();
        }

        private static void FillProperties(
            SqlCommand sqlCommand,
            string productName,
            bool discontinued,
            int? supplierID = null,
            int? categoryID = null,
            string quantityPerUnit = null,
            decimal unitPrice = 0,
            short unitsInStock = 0,
            short unitsOnOrder = 0,
            short reorderLevel = 0)
        {
            sqlCommand.Parameters.AddWithValue("@ProductName", productName);
            sqlCommand.Parameters.AddWithValue("@Discontinued", discontinued);
            if ((supplierID != null))
            {
                sqlCommand.Parameters.AddWithValue("@SupplierID", supplierID);
            }
            else 
            {
                sqlCommand.Parameters.AddWithValue("@SupplierID", DBNull.Value); 
            }

            if (categoryID != null)
            {
                sqlCommand.Parameters.AddWithValue("@CategoryID", categoryID); 
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@CategoryID", DBNull.Value); 
            }

            if (quantityPerUnit != null)
            {
                sqlCommand.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit); 
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@QuantityPerUnit", DBNull.Value); 
            }

            sqlCommand.Parameters.AddWithValue("@UnitPrice", unitPrice);
            sqlCommand.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
            sqlCommand.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
            sqlCommand.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
        }
    }
}
