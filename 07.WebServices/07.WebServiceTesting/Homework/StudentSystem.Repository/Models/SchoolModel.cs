namespace SchoolSystem.Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using SchoolSystem.Models;

    public class SchoolModel
    {
        public static Expression<Func<School, SchoolModel>> FormSchool
        {
            get { return x => new SchoolModel { SchoolId = x.SchoolId, Name = x.Name, Location = x.Location }; }
        }

        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public IEnumerable<StudentModel> Students { get; set; }

    }
}
