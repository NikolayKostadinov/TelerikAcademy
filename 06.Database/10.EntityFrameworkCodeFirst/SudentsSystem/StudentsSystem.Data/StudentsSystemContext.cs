namespace StudentsSystem.Data
{
    using StudentsSystem.Model;
    using System;
    using System.IO;
    using System.Data.Entity;
    
    public class StudentsSystemContext : DbContext 
    {
        public StudentsSystemContext()
            : base("StudentsSystemWork") 
        { 
        }
   
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Homework> Homeworks { get; set; }
    }
}
