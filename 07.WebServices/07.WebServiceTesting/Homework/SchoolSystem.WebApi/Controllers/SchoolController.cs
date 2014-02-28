using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolSystem.Models;
using SchoolSystem.Data;
using SchoolSystem.Repository;
using SchoolSystem.Repository.Models;


namespace SchoolSystem.WebApi.Controllers
{
    public class SchoolController : ApiController
    {

        private readonly IRepository<School> repository;

        public SchoolController(IRepository<School> repository) 
        {
            this.repository = repository;
        }

        public SchoolController() 
        {
            this.repository = new EfRepository<School>(new SchoolContext());
        }

        // GET api/school
        public IQueryable<SchoolModel> Get()
        {
            var schools = this.repository.All().Select(SchoolModel.FormSchool);
            foreach (var school in schools)
            {
                int id = school.SchoolId;
                school.Students = this.repository.All().Where(x => x.SchoolId == id).FirstOrDefault().Students.AsQueryable().Select(StudentModel.FormStudent);
            }
            return schools;
        }

        //GET api/school/5
        public SchoolModel Get(int id)
        {
            var school = this.repository.All().Where(x => x.SchoolId == id).Select(SchoolModel.FormSchool).FirstOrDefault();
            school.Students = this.repository.All().Where(x => x.SchoolId == id).FirstOrDefault().Students.AsQueryable().Select(StudentModel.FormStudent);            
            return school;
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
        public void Delete(int id)
        {
        }
    }
}
