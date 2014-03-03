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
        public IEnumerable<SchoolModel> Get()
        {
            var schools = this.repository.All().Select(SchoolModel.FormSchool);
            


            return schools;
        }

        //GET api/school/5
        public SchoolDetailedModel Get(int id)
        {
            var school = this.repository.All().Where(x => x.SchoolId == id).Select(SchoolDetailedModel.FormSchool).FirstOrDefault();      
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

            string successMessage = string.Format("Record ID {0} was deleted", id);

            return this.Request.CreateResponse(HttpStatusCode.Accepted, successMessage);
        }
    }
}
