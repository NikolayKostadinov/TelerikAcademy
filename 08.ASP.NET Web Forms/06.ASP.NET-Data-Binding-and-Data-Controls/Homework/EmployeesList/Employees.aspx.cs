using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeesList.Models;

namespace EmployeesList
{
    public partial class Employees : System.Web.UI.Page
    {
        static List<Employee> employees;

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
                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }
        }

        protected void GridViewEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int pagenumber = e.NewPageIndex;
            this.GridViewEmployees.PageIndex = pagenumber;
            this.GridViewEmployees.DataSource = employees;
            this.GridViewEmployees.DataBind();
        }
    }
}