using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using HttpClientFormsAuthSample.Client;

namespace MyClientAuth
{
    class User 
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Username:");
            var username = Console.ReadLine();
            Console.WriteLine("Password:");
            var password = Console.ReadLine();
            string uri = "http://localhost:3915/Account/Login";
            var client = new HttpClient();

            var response = client.PostAsync(uri, new User() { Username = username, Password = password }, new JsonMediaTypeFormatter()).Result;
            IEnumerable<string> values;
            response.Headers.TryGetValues("Set-Cookie", out values);
            if (null == values || string.IsNullOrEmpty(values.First()))
            {
                Console.WriteLine("Invalid Username or password;");
            }
            else 
            {
                string newUri = "http://localhost:3915/customer/get/1";
                string cookie = values.First();
                client.DefaultRequestHeaders.Add("Cookie", cookie);
                var getRequestResponse = client.GetAsync(newUri).Result;

                Customer customer = getRequestResponse.Content.ReadAsAsync<Customer>().Result;

                Console.WriteLine("Customer Id: {0}; Name: {1}", customer.Id, customer.Name);
            }

            Console.ReadLine();
        }
    }
}
