using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        protected void AddNewButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ListViewCategories.InsertItemPosition = InsertItemPosition.LastItem; 
        }

        protected void InsertButton_Click1(object sender, EventArgs e)
        {
            this.ListViewCategories.InsertItemPosition = InsertItemPosition.None;
        }

        protected void InsertToDoButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ListViewTodo.InsertItemPosition = InsertItemPosition.None;
        }

        protected void AddNewToDoButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ListViewTodo.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CancelButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ListViewTodo.InsertItemPosition = InsertItemPosition.None;
        }

        protected void CalendarInsertDateOfLastChange_PreRender(object sender, EventArgs e)
        {
            var calendar = sender as Calendar;
            if (!(calendar.SelectedDate > DateTime.MinValue)) 
            {
                calendar.SelectedDate = DateTime.Now;
            }
        }

        protected void UpdateButton_Unload(object sender, EventArgs e)
        {
            this.ListViewTodo.DataBind();
        }
    }
}