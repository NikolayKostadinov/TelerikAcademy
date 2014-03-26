using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Repository;

namespace SchoolSystem.WebApi.Helpers
{
    public static class StudentServiceHelper
    {
        public static void DeleteChilds(this IRepository<Student> sc, int studentId)
        {
            Student student = sc.All().Where(x => x.StudentId == studentId).FirstOrDefault();
            var marksRepository = new EfRepository<Mark>(new SchoolContext()); 
            
            if (student != null)
            {
                foreach (Mark mark in student.Marks) 
                {
                    marksRepository.Delete(mark.MarkId);
                }
            }
        }
    }
}