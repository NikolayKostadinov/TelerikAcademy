namespace AppendLinesToExcel
{
    using System;
    using System.Data.OleDb;
    class AppendLinesToExcel
    {
        static void Main()
        {
            string connectionString = Settings1.Default.xlsxConectionString;
            OleDbConnection connection = new OleDbConnection(connectionString);
            string commantString = @"INSERT INTO [Sheet1$] (Name, Scores)
                               VALUES (@Name, @Scores)";
            OleDbCommand command = new OleDbCommand(commantString, connection);
            string name = "Вуйчо Ваньо";
            double score = 20;
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Scores", score);
            connection.Open();
            using (connection)
            {
                Console.WriteLine(command.ExecuteNonQuery());
            }
            connection.Close();
        }
    }
}
