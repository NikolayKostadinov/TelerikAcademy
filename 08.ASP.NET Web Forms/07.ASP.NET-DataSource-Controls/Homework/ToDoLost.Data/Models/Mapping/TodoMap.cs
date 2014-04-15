using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDoList.Data.Models.Mapping
{
    public class TodoMap : EntityTypeConfiguration<Todo>
    {
        public TodoMap()
        {
            // Primary Key
            this.HasKey(t => t.TodoId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Todos");
            this.Property(t => t.TodoId).HasColumnName("TodoId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Boby).HasColumnName("Boby");
            this.Property(t => t.DateOfLastChange).HasColumnName("DateOfLastChange");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Todos)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
