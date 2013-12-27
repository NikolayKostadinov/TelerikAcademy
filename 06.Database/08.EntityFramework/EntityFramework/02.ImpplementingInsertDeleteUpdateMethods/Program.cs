namespace ImpplementingInsertDeleteUpdateMethods
{
    using System;
    using System.Linq;
    using NorthwindModel;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int affectedRecords = Dao.InsertCustomer("Pavlina Kostadinova", "Paverony1");
                Console.WriteLine("The number of affected records is: {0}", affectedRecords);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int affectedRecords = Dao.ModifyCustomer("Pavlina Dojkova", "Paverony1");
                Console.WriteLine("The number of affected records is: {0}", affectedRecords);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int affectedRecords = Dao.DeleteCustomer("Paverony1");
                Console.WriteLine("The number of affected records is: {0}", affectedRecords);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
