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
using SchoolSystem.WebApi.Helpers;


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
        public HttpResponseMessage Post([FromBody]School value)
        {
            try
            {
                this.repository.Add(value);
                var response = Request.CreateResponse<School>(HttpStatusCode.Created, value);
                var resourceLink = Url.Link("DefaultApi", new { id = value.SchoolId });
                response.Headers.Location = new Uri(resourceLink);
                return response;
            }

            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return response;
            }
        }

        // PUT api/school/5
        public HttpResponseMessage Put(int id, [FromBody]School school)
        {
            if (this.repository.Get(id) != null)
            {
                this.repository.Update(id, school);
                return this.Request.CreateResponse(HttpStatusCode.Accepted);
            }
            else 
            {
                var response = this.Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "The record you have try to change not found!";
                return response;
            }
        }

        // DELETE api/school/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                this.repository.DeleteChilds(id);
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
