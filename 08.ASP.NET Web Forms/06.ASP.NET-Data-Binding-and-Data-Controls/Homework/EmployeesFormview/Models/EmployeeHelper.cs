using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeesFormview.Models
{
    public partial class Employee
    {
        public string FullName
        {
            get 
            { 
                return this.FirstName + " " + this.LastName; 
            }
        }
    }
}