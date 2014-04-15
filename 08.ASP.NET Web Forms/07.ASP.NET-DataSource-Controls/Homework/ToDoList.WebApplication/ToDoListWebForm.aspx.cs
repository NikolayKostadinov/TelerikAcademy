using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList.WebApplication
{
    public partial class ToDoListWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ListView1.InsertItemPosition = InsertItemPosition.LastItem; 
        }

        protected void InsertButton_Click1(object sender, EventArgs e)
        {
            this.ListView1.InsertItemPosition = InsertItemPosition.None;
        }
    }
}