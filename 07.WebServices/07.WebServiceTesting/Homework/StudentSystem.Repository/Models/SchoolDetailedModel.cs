namespace SchoolSystem.Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using SchoolSystem.Models;

    public class SchoolDetailedModel
    {
        public static Expression<Func<School, SchoolDetailedModel>> FormSchool
        {
            get { return x => new SchoolDetailedModel { SchoolId = x.SchoolId, Name = x.Name, Location = x.Location, Students = x.Students.AsQueryable().Select(StudentDetailedModel.FormStudent) }; }
        }

        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public IQueryable<StudentDetailedModel> Students { get; private set; }

    }
}
