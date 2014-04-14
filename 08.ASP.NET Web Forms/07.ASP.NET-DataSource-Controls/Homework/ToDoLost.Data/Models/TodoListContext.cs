using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ToDoLost.Data.Models.Mapping;

namespace ToDoLost.Data.Models
{
    public partial class TodoListContext : DbContext
    {
        static TodoListContext()
        {
            Database.SetInitializer<TodoListContext>(null);
        }

        public TodoListContext()
            : base("Name=TodoListContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new TodoMap());
        }
    }
}
