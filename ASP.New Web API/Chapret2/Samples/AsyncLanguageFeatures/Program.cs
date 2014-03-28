using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLanguageFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrint();
            Console.ReadLine();
        }

        private static async void ConsolePrint()
        {
            Console.WriteLine(await DowloadPageAsync("http://zamunda.org"));
        }

        private static async Task<string> DowloadPageAsync(string uri)
        {
            using (WebClient client = new WebClient())
            {
                string htmlString = await client.DownloadStringTaskAsync(uri);
                return htmlString;
            }
        }
    }
}
