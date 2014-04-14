using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ToDoLost.Data.Models;
using ToDoList.Repositories;

namespace ToDoList.WebApplication
{
    public class ToDoDataProvider
    {
        private IRepository<Category> categories = new EfRepository<Category>(new TodoListContext());
        
        public IRepository<Category> Categories
        {
            get { return this.categories; }
        }

        public IQueryable<Category> GetAllCategories() 
        {
            return this.categories.All();
        }
    }
}