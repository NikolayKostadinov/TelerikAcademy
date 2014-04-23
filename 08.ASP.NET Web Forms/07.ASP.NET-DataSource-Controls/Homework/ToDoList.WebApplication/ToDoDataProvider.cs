using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Data.Models;
using ToDoList.Repositories;

namespace ToDoList.WebApplication
{
    public class ToDoDataProvider
    {
        private IRepository<Todo> todos = new EfRepository<Todo>(new TodoListContext());

        public IRepository<Todo> Todos
        {
            get { return this.todos; }
        }

        public ICollection<Todo> GetAllToDos()
        {
            return this.todos.All().ToList();
        }

        public ICollection<Todo> GetAllToDos(int categoryId)
        {
            return this.todos.All().Where(x => x.CategoryId == categoryId).ToList();
        }

        public void DeleteTodo(Todo todo)
        {
            this.todos.Delete(todo.TodoId);
        }

        public void UpdateToDo(Todo todo)
        {
            this.todos.Update(todo.TodoId, todo);
        }

        public void InsertTodo(Todo todo)
        {
            this.todos.Add(todo);
        }
    }
}