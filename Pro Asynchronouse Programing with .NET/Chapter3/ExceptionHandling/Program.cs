using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(() => { throw new Exception("Boom!"); });
            t = null;
            var objects = new object[10000];
            int i = 0;
            while (true)
            {
                objects[i++] = new object();
                i = i % objects.Length;
            }
        }
    }
}
