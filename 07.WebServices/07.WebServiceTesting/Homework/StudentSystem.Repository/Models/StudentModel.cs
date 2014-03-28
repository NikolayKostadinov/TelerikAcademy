namespace SchoolSystem.Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using SchoolSystem.Data;
    using SchoolSystem.Models;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FormStudent
        {

            get
            {
                return x => new StudentModel
                {
                    StudentId = x.StudentId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Grade = x.Grade,
                    SchoolName = x.School != null ? x.School.Name : string.Empty,
                    SchoolId = x.School != null ? x.School.SchoolId : 0,
                };
            }
        }

        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public string SchoolName { get; set; }

        public int SchoolId { get; set; }

    }
}
