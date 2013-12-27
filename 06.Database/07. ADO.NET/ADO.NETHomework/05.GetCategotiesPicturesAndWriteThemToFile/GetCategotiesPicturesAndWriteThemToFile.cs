namespace GetCategotiesPicturesAndWriteThemToFile
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing.Imaging;
    using System.IO;

    class GetCategotiesPicturesAndWriteThemToFile
    {
        // TODO: Write a program that retrieves the images for all categories 
        // in the Northwind database and stores them as JPG files in the file system.

        static void Main()
        {
            string connectionString = Settings1.Default.NorthwindConnectionString;
            SqlConnection northwindConnection = new SqlConnection(connectionString);
            string query = @"SELECT FirstName + LastName, Photo
                                FROM Employees";
            SqlCommand selectNumnerOfCategories = new SqlCommand(query, northwindConnection);
            northwindConnection.Open();

            using (northwindConnection)
            {
                var dataReader = selectNumnerOfCategories.ExecuteReader();

                while (dataReader.Read())
                {
                    WritePictureToFile((string)dataReader[0] + ".jpg", (byte[])dataReader[1]);
                }
            }

            northwindConnection.Close();
            Console.WriteLine("Ready to use !!!");
        }

        private static void WritePictureToFile(string fileName, byte[] rawData)
        {
            if (rawData == null) return;
            fileName = fileName.Replace(@"/", "_");
            if (File.Exists(fileName)) File.Delete(fileName);

            int header = 78;
            byte[] imgData = new byte[rawData.Length - header];
            Array.Copy(rawData, 78, imgData, 0, rawData.Length - header);

            using (MemoryStream memoryStream = new MemoryStream(imgData))
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                image.Save(new FileStream(fileName, FileMode.Create), ImageFormat.Jpeg);
            }
        }
    }
}

