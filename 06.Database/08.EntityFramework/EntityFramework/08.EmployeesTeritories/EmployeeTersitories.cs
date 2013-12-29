using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindModel;

namespace EmployeeTeritories
{
    internal class EmployeeTersitories
    {
        private static void Main(string[] args)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                IEnumerable<Employee> employees = (from empl in dbContext.Employees
                                     select empl);
                foreach (var employee in employees)
                {
                    Console.WriteLine("{0} {1} {2}", employee.EmployeeID, employee.FirstName, employee.LastName );
                    foreach (var teritory in employee.Territories)
                    {
                        Console.WriteLine("{0} | {1}", teritory.TerritoryID, teritory.TerritoryDescription);
                    }
                }
            }
        }
    }
}
