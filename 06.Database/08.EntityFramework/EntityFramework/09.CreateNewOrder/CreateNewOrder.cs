namespace CreateNewOrder
{
    using System;
    using System.Data.Entity.Core;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using NorthwindModel;
    using System.Transactions;

    class CreateNewOrder
    { // TODO: Create a method that places a new order in the Northwind database. 
        // The order should contain several order items. 
        // Use transaction to ensure the data consistency.

        static void Main()
        {
            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.Now;
            newOrder.RequiredDate = DateTime.Now + new TimeSpan(3, 0, 0, 0); //thre days later
            newOrder.ShipCountry = "Bulgaria";
            newOrder.ShipCity = "Burgas";
            int numberOfRepeatsUntilSuccess = 3;
            try
            {
                CreateOrder(newOrder, numberOfRepeatsUntilSuccess);
            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine("{0} \n{1}", ex.Message, ex.InnerException.Message);
            }
        }

        private static void CreateOrder(Order newOrder, int numberOfRepeatsUntillSuccess)
        {
            bool isTransactionSucceed = false;
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    for (int i = 0; i < numberOfRepeatsUntillSuccess; i++)
                    {
                        try
                        {
                            dbContext.Orders.Add(newOrder);
                            dbContext.SaveChanges();
                            transaction.Complete();
                            isTransactionSucceed = true;
                            break;
                        }
                        catch (UpdateException ex)
                        {
                            if (i == numberOfRepeatsUntillSuccess - 1)
                            {
                                throw new InvalidOperationException("Cannot complete order creation", ex);
                            }
                        }
                    }

                    if (isTransactionSucceed)
                    {
                        // Reset the context since the operation succeeded.
                        Console.WriteLine("Transaction sompited");
                    }
                    else
                    {
                        Console.WriteLine("The operation could not be completed in "
                            + numberOfRepeatsUntillSuccess + " tries.");
                    }
                }
            }
        }
    }
}
