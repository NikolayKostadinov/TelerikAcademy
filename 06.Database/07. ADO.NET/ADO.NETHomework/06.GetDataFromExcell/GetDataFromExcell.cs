namespace GetDataFromExcell
{   
    using System;
    using System.Data.OleDb;
    internal class GetDataFromExcell
    {
        private static void Main()
        {
            string connectionString = Settings1.Default.xlsxConectionString;
            OleDbConnection excelFileConnection = new OleDbConnection(connectionString);
            excelFileConnection.Open();

            using (excelFileConnection)
            {
                string command = @"SELECT * FROM [Sheet1$]";
                OleDbCommand readNamespaceAndScores = new OleDbCommand(command, excelFileConnection);
                var dataReader = readNamespaceAndScores.ExecuteReader();

                string headerColumn1 = dataReader.GetName(0).PadLeft((50 - dataReader.GetName(0).Length) / 2 + dataReader.GetName(0).Length, ' ');
                string headerColumn2 = dataReader.GetName(1).PadLeft((10 - dataReader.GetName(1).Length) / 2 + dataReader.GetName(1).Length, ' ');
                string header = string.Format("{0,-50}|{1,-10}", headerColumn1, headerColumn2);

                Console.WriteLine(header);
                Console.WriteLine(new string('-', header.Length));
                while (dataReader.Read()) 
                {
                    Console.WriteLine("{0,-50}|{1,10}", dataReader[0].ToString() , dataReader[1].ToString());
                }
            }

        }
    }
}
