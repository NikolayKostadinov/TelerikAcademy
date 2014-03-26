using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpClientConneg.WebApi.Controllers {
    public class CustomerController : ApiController {
        private static ICollection<Customer> customers = new List<Customer>(); 
         public Customer Get(int id) {
             return new Customer() {
                Id = id,
                Name = "Apress"
             };
         }

         public HttpResponseMessage Post(Customer customer) 
         {
             customers.Add(customer);
             customer.Id = customers.Count - 1;
             return Request.CreateResponse(HttpStatusCode.Created, customer);
         }
    }

    public class Customer {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}