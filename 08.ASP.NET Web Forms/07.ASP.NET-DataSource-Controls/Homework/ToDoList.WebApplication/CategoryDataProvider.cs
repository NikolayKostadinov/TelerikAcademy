using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ToDoList.Data.Models;
using ToDoList.Repositories;

namespace ToDoList.WebApplication
{
    public class CategoryDataProvider
    {
        private IRepository<Category> categories = new EfRepository<Category>(new TodoListContext());
        
        public IRepository<Category> Categories
        {
            get { return this.categories; }
        }

        public ICollection<Category> GetAllCategories() 
        {
            return this.categories.All().ToList();
        }

        public void DeleteCategory(Category category) 
        {
            this.categories.Delete(category.CategoryId);
        }

        public void UpdateCategory(Category category)
        {
            this.categories.Update(category.CategoryId, category);
        }

        public void InsertCategory(Category category) 
        {
            this.categories.Add(category);
        }
    }
}