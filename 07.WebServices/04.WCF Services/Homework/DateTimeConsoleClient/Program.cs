using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeConsoleClient
{
    class Program
    {
        static void Main()
        {
            var client = new DateTimeConsoleClient.DateNamer.NameOfDateClient();
            while (true)
            {
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine(client.GetNameOfDate(date));   
            }
        }
    }
}
