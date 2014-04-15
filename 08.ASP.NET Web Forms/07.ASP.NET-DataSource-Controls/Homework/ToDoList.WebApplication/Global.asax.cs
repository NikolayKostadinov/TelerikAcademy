using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ToDoList.Data.Migrations;
using ToDoList.Data.Models;
using ToDoList.Repositories;

namespace ToDoList.WebApplication
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoListContext, Configuration>());
        }
    }
}