namespace SchoolSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using SchoolSystem.Models;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("SchoolDbHome")
        {
        }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetUpSchoolsEntity(modelBuilder);
            SetUpStudentsEntity(modelBuilder);
            SetUpMarksEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void SetUpMarksEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mark>()
                .ToTable("Marks")
                .HasKey(x => x.MarkId);

            modelBuilder.Entity<Mark>()
                .Property(x => x.Subject)
                .IsRequired().HasMaxLength(20)
                .IsUnicode(true);
        }

        private static void SetUpStudentsEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable("Students")
                .HasKey(x => x.StudentId);

            modelBuilder.Entity<Student>()
                .Property(x => x.FirstName)
                .IsRequired().HasMaxLength(20)
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(x => x.LastName)
                .IsRequired().HasMaxLength(20)
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(x => x.Grade)
                .IsRequired();
        }

        private static void SetUpSchoolsEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .ToTable("Schools")
                .HasKey(x => x.SchoolId);

            modelBuilder.Entity<School>()
                .Property(x => x.Name)
                .IsRequired().HasMaxLength(30)
                .IsUnicode(true);

            modelBuilder.Entity<School>()
                .Property(x => x.Location)
                .IsRequired().HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder.Entity<School>()
                .Property(x => x.Name)
                .IsOptional().HasMaxLength(50)
                .IsUnicode(true);
        }
    }
}
