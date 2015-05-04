using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTaskWithInputParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello World";
            for (int i = 0; i < 10; i++)
            {
                int toCapture = i;
                Task.Factory.StartNew(() => Console.WriteLine(str + " " + toCapture));
            }
            Console.ReadKey();
            Console.WriteLine("---- Strange site effect in foreach in value capturing ----");
            var inItems = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var item in inItems)
            {
                Task.Factory.StartNew(() => Console.WriteLine(str + " " + item));
            }
            Console.ReadLine(); 
        }
 
        /// <summary>
        /// Consoles the write.
        /// </summary>
        /// <param name="str">The STR.</param>
        private static void ConsoleWrite(string str)
        {
            Console.WriteLine(str);
        }

    }
}
