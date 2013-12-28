namespace CopyNorthwindDatabase
{
    using System;
    using System.Linq;
    using NorthwindModel;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    class CopyNorthwindDatabase
    {
        //TODO: Create a database called NorthwindTwin with the same structure as 
        // Northwind using the features from DbContext. Find for the API for 
        // schema generation in MSDN or in Google.


        static void Main()
        {
            IObjectContextAdapter context = new NorthwindEntities();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

            string createNorthwindCloneDB = 
                "CREATE DATABASE NorthwindTwin ON PRIMARY " +
                "(NAME = NorthwindTwin, " +
                "FILENAME = 'D:\\NorthwindTwin.mdf', " +
                "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = NorthwindTwin_Log, " +
                "FILENAME = 'D:\\NorthwindTwinLog.ldf', " +
                "SIZE = 5MB, " +
                "MAXSIZE = 10MB, " +
                "FILEGROWTH = 10%)";

            SqlConnection dbConForCreatingDB = new SqlConnection(
                @"Data Source=S_MANHATTAN;
                Persist Security Info=True;
                User ID=Manhattan;
                Password=123;
                Initial Catalog=master");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                SqlCommand createDB = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
                createDB.ExecuteNonQuery();
            }

            SqlConnection dbConForCloning = new SqlConnection(
                @"Data Source=S_MANHATTAN;
                Persist Security Info=True;
                User ID=Manhattan;
                Password=123;
                Initial Catalog=NorthwindTwin");

            dbConForCloning.Open();

            using (dbConForCloning)
            {
                SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCloning);
                cloneDB.ExecuteNonQuery();
            }
        }
    }
}
