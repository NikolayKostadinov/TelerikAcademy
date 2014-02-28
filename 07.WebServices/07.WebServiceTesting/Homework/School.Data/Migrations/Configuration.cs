namespace SchoolSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SchoolSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var marks = GenerateMarks();

            var students = GenerateStudents(marks);

            var schools = GenerateSchools();

            for (int i = 0; i < 3; i++)
            {
                PopulateSchoolWithStudents(schools[i], students[i]);
            }

            foreach (var marksarr in marks)
            {
                context.Marks.AddOrUpdate(marksarr);
            }

            foreach (var studentsarr in students)
            {
                context.Students.AddOrUpdate(studentsarr);
            }

            context.Schools.AddOrUpdate(schools);
        }

        private Mark[][] GenerateMarks()
        {
            var marks = new Mark[][] 
            {
                new Mark[]
                { 
                    new Mark(){ Subject = "Biology", Value = 3},
                    new Mark(){ Subject = "Geography", Value = 5},
                    new Mark(){ Subject = "Math", Value = 6},
                },

                new Mark[]
                { 
                    new Mark(){ Subject = "Biology", Value = 4},
                    new Mark(){ Subject = "Geography", Value = 4},
                    new Mark(){ Subject = "Math", Value = 4},
                },

                new Mark[]
                { 
                    new Mark(){ Subject = "Biology", Value = 3.5m},
                    new Mark(){ Subject = "Geography", Value = 5},
                    new Mark(){ Subject = "Math", Value = 5.5m},
                },

                new Mark[]
                { 
                    new Mark(){ Subject = "Biology", Value = 4},
                    new Mark(){ Subject = "Geography", Value = 5},
                    new Mark(){ Subject = "Math", Value = 4},
                },

                new Mark[]
                { 
                    new Mark(){ Subject = "Biology", Value = 3},
                    new Mark(){ Subject = "Geography", Value = 5},
                    new Mark(){ Subject = "Math", Value = 5},
                },

                new Mark[]
                { 
                    new Mark(){ Subject = "Biology", Value = 3},
                    new Mark(){ Subject = "Geography", Value = 4},
                    new Mark(){ Subject = "Math", Value = 6},
                },
            };
            return marks;
        }

        private static Student[][] GenerateStudents(Mark[][] marks)
        {
            var students1 = new Student[]
            {
                new Student(){ FirstName = "Nikolay", LastName="Kostadinov", Grade = 10, Age = 18, Marks = marks[0]},
                new Student(){ FirstName = "Hristo", LastName="Grigorov", Grade = 5, Age = 12, Marks = marks[1]},                
            };

            var students2 = new Student[]
            {
                new Student(){ FirstName = "Ceca", LastName="Meca", Grade = 3, Age = 10, Marks = marks[2]},
                new Student(){ FirstName = "Kaka", LastName="Svetka", Grade = 8, Age = 14, Marks = marks[3]},                
            };

            var students3 = new Student[]
            {
                new Student(){ FirstName = "Kumcho", LastName="Valchev", Grade = 10, Age = 18, Marks = marks[4]},
                new Student(){ FirstName = "Mitko", LastName="Mitkov", Grade = 6, Age = 13, Marks = marks[5]},                
            };

            return new Student[][] { students1, students2, students3 };
        }

        private static School[] GenerateSchools()
        {
            var schools = new School[] 
            {
                new School() {  Name="Konstantin Preslavski", Location="gr. Burgas, bof. Izgrev" },
                new School() {  Name="Konstantin Petkanov", Location="gr. Burgas, bof. Meden Rudnik" },
                new School() {  Name="Vasil Aprilov", Location="gr. Burgas, bof. Lazur" },
            };
            return schools;
        }

        private static void PopulateSchoolWithStudents(School school, IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                school.Students.Add(student);
            }
        }
    }
}
