namespace FeedzillaReader.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FeedzillaReader.Models;
    using Newtonsoft.Json;
    class Program
    {
        public static bool over = false;

        private static async Task<HttpAnswer> ReadNews(HttpClient httpClient, string uri, string query, int count)
        {
            var responce = await httpClient.GetAsync(uri + "?q=" + query + "&count=" + count);
            //System.Threading.Thread.Sleep(15000);
            HttpAnswer answer = JsonConvert.DeserializeObject<HttpAnswer>(await responce.Content.ReadAsStringAsync());
            return answer;
        }

        static void Main()
        {
            Console.Write("Enter searched criteria: ");
            string query = Console.ReadLine();
            Console.Write("Enter maximal number of results: ");
            int count = int.Parse(Console.ReadLine());

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/");
            string serviceUri = "v1/articles/search.json";
            WaitingForReply(httpClient, serviceUri, query, count);

            int ix = 0;
            string symbols = @"\|/-";
            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;
            while (!over)
            {
                Console.SetCursorPosition(cursorX, cursorY);
                Console.WriteLine("Waiting for reply " + symbols[ix]);
                ix = (ix == symbols.Length - 1) ? ix = 0 : ++ix;
                System.Threading.Thread.Sleep(100);
            }
        }

        private static async void WaitingForReply(HttpClient httpClient, string serviceUri, string query, int count)
        {
            ConsolePrint(await ReadNews(httpClient, serviceUri, query, count));
        }

        private static void ConsolePrint(HttpAnswer httpAnswer)
        {
            over = true;
            int number = 1;
            foreach (Article article in httpAnswer.Articles)
            {
                Console.WriteLine("{0}\t{1}\t{2}", number++, article.Title, article.SourceUrl);
            }
        }
    }
}
