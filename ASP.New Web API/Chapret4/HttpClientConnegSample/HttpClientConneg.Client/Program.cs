using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;

namespace HttpClientConneg.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:12345/api/customer";

            //var client = new HttpClient();
            //var response = client.GetAsync(uri+"/1").Result;
            //var customer = response.Content.ReadAsAsync<Customer>().Result;
            //Console.WriteLine("Id: {0}, Name: {1}", customer.Id, customer.Name);
            //Console.ReadLine();

            var customer1 = new Customer()
            {
                Name = "My Customer",
            };

            var customer2 = new Customer()
            {
                Name = "My Customer1",
            };

            PostCustomer(uri, customer1);
            PostCustomer(uri, customer2);
            Console.ReadLine();
        }
  
        private static void PostCustomer(string uri, Customer customer)
        {
            var httpClient = new HttpClient();
            httpClient.PostAsync(uri, customer, new JsonMediaTypeFormatter())
                      .ContinueWith(t =>
                      {
                          if (t.Result.StatusCode == HttpStatusCode.Created)
                          {
                              t.Result.Content.ReadAsAsync<Customer>().ContinueWith(
                                  tr =>
                                  {
                                      Console.WriteLine("Id: {0}, Name: {1}", tr.Result.Id, tr.Result.Name);
                                  });
                          }
                      });
        }
    }
}
