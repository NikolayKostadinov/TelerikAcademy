namespace ConcurentChanges
{
    using System;
    using System.Linq;
    using NorthwindModel;

    class ConcurentChanges
    {
        //TODO: Try to open two different data contexts and perform concurrent changes on the same records. 
        //      What will happen at SaveChanges()? How to deal with it?

        static void Main()
        {
            string companyName = "Concurency Test";
            string contactName = "Concurent1";
            string contactName2 = "Concurent2";

            using (NorthwindEntities db = new NorthwindEntities())
            {
                using(NorthwindEntities db2 = new NorthwindEntities())
                {
                    string id = GetCustomerId(companyName);
                    var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                    var customer2 = db2.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                    if (customer == null) throw new ArgumentException("The record you are trying to modify doesn't exist!!!");
                    customer.CompanyName = companyName;
                    customer.ContactName = contactName;
                    customer2.ContactName= contactName2;
                    db.SaveChanges();
                    db2.SaveChanges();
                }
            }
        }

        public static string GetCustomerId(string customerOrganization)
        {
            string customerId = customerOrganization.Substring(0, 5).ToUpper();
            return customerId;
        }
    }
}
