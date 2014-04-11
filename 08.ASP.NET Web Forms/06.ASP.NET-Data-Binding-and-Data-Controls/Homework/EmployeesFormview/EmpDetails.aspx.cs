using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeesFormview.Models;

namespace EmployeesFormview
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        static List<Employee> employees;

        static EmpDetails() 
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                employees = context.Employees.ToList();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeId = int.Parse(this.Request["id"] ?? "0");
            var employee = employees[employeeId];
            var selectedEmployee = (from em in employees
                                    where (em.EmployeeID == employeeId)
                                    select (em));
            this.FormViewEmployeeDetails.DataSource = selectedEmployee;
            this.FormViewEmployeeDetails.DataBind();
        }
    }
}