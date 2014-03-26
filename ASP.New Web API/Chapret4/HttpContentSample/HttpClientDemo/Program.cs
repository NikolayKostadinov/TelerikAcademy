using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static void Main()
        {
            string uri = "https://raw.github.com/AlexZeitler/HttpClient/master/README.md";
            var httpClient = new HttpClient();
            httpClient.GetStringAsync(uri).ContinueWith(t =>
            {
                Console.WriteLine(t.Result);
            });
            Console.ReadLine();
        }
    }
}
