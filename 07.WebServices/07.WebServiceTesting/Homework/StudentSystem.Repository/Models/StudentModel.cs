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
            get { return x => new StudentModel { ModelId = x.StudentId, FirstName = x.FirstName, LastName = x.LastName, Age = x.Age}; }
        }

        public int ModelId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
