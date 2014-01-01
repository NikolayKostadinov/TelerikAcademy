namespace StudentsSystem.Data
{
    using StudentsSystem.Model;
    using System;
    using System.Data.Entity;
    
    public class StudentsSystemContext : DbContext 
    {
        public StudentsSystemContext()
            : base("StudentsSystem") 
        { 
        }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Homework> Homeworks { get; set; }
    }
}
