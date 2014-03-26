using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventBasedAsynchronousPatternUsingWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(SuccessHandler); 
            client.DownloadStringAsync(new Uri("http://example.com"));
            Console.ReadLine();
        }

        private static void SuccessHandler(object sender, DownloadStringCompletedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Result);
        }


    }
}
