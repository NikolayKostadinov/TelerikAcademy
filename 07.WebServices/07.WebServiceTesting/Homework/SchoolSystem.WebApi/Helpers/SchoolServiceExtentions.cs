using System;
using System.Linq;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Repository;

namespace SchoolSystem.WebApi.Helpers
{
    public static class SchoolServiceExtentions
    {
        public static void DeleteChilds(this IRepository<School> sc, int schoolId) 
        {
            var studentsRepo = new EfRepository<Student>(new SchoolContext());

            var studentsFromSchool = studentsRepo.All().Where(x => x.SchoolId == schoolId).ToList();



            foreach (Student student in studentsFromSchool)
            {
                studentsRepo.DeleteChilds(student.SchoolId);
                studentsRepo.Delete(student.StudentId);
            }
        }
    }
}