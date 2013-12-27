// Create a DAO class with static methods which provide functionality for 
// inserting, modifying and deleting customers. Write a testing class.

namespace ImpplementingInsertDeleteUpdateMethods
{
    using NorthwindModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dao
    {
        public static int InsertCustomer(string contactName, string companyName)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {

                Customer customer = new Customer()
                {
                    ContactName = contactName,
                    CompanyName = companyName,
                    CustomerID = GetCustomerId(companyName),
                };

                if (IsCustomerExists(db, GetCustomerId(companyName)))
                {
                    throw new ArgumentException("Customer already exist!!!");
                }

                db.Customers.Add(customer);
                return db.SaveChanges();
            }
        }

        public static int ModifyCustomer(string contactName, string companyName)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                string id = GetCustomerId(companyName);
                var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                if (customer == null) throw new ArgumentException("The record you are trying to modify doesn't exist!!!");
                customer.CompanyName = companyName;
                customer.ContactName = contactName;
                return db.SaveChanges();
            }
        }

        public static int DeleteCustomer(string companyName)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                string id = GetCustomerId(companyName);
                if (IsCustomerExists(db, id))
                {
                    Customer customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                    db.Customers.Remove(customer);
                    return db.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static bool IsCustomerExists(NorthwindEntities db, string customerId)
        {
            bool alreadyInDB = db.Customers.Where(customer => customer.CustomerID == customerId).Any();
            return alreadyInDB;
        }

        public static string GetCustomerId(string customerOrganization)
        {
            string customerId = customerOrganization.Substring(0, 5).ToUpper();
            return customerId;
        }
    }
}
