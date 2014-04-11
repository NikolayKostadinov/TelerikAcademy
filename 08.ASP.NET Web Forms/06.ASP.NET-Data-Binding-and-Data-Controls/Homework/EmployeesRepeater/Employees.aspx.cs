using System;
using System.Collections.Generic;
using System.Linq;
using EmployeesRepeater.Models;

namespace EmployeesRepeater
{
    public partial class Employees : System.Web.UI.Page
    {
       static List<EmployeesRepeater.Models.Employee> employees;

        static Employees() 
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                employees = context.Employees.ToList();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.RepeaterEmployees.DataSource = employees;
                this.RepeaterEmployees.DataBind();
            }
        }
    }
}