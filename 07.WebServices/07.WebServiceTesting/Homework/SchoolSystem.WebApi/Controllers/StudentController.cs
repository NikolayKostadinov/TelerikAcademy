using System.Net.Http;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;

namespace SchoolSystem.WebApi.Controllers
{
    public class StudentController : ApiController
    {
         private readonly IRepository<Student> repository;

        public StudentController(IRepository<Student> repository) 
        {
            this.repository = repository;
        }

        public StudentController() 
        {
            this.repository = new EfRepository<Student>(new SchoolContext());
        }

        // GET api/school
        public IEnumerable<StudentModel> Get()
        {
            return this.repository.All().Select(StudentModel.FormStudent);
        }

        //GET api/school/5
        public StudentDetailedModel Get(int id)
        {
            return this.repository.All().Where(x => x.StudentId == id).Select(StudentDetailedModel.FormStudent).FirstOrDefault();      
        }

        public IQueryable<StudentDetailedModel> GetStudentBySchool(int schoolId)
        {
            return this.repository.All().Where(x => x.SchoolId == schoolId).Select(StudentDetailedModel.FormStudent);
        }

        // POST api/school
        public void Post([FromBody]string value)
        {
        }

        // PUT api/school/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/school/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                this.repository.Delete(id);
            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);  
            }

            string successMessage = string.Format("Record ID {0} was deleted",id);

            return this.Request.CreateResponse(HttpStatusCode.Accepted, successMessage);
        }

    }
}
