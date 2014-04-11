using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeesRepeater.Models
{
    public partial class Employee
    {
        public string GatFullName
        {
            get 
            { 
                return this.FirstName + " " + this.LastName; 
            }
        }
    }
}