using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(Speak);
            t.Wait();
            Console.WriteLine("All work is done!");
        }
 
        /// <summary>
        /// Speaks this instance.
        /// </summary>
        private static void Speak()
        {
            Console.WriteLine("Hello World");
        }
    }
}
