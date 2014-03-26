using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskBasedAsynchronousPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var doWorkAsynk = DoWorkAsync();
            if (doWorkAsynk.IsCompleted)
            {
                Console.WriteLine(doWorkAsynk.Result);
            }
            else
            {
                DoWorkAsync().ContinueWith(task =>
                {
                    Console.WriteLine(task.Result);
                }, TaskContinuationOptions.NotOnFaulted);

                DoWorkAsync().ContinueWith(task =>
                {
                    Console.WriteLine(task.Exception.InnerException.Message);
                }, TaskContinuationOptions.OnlyOnFaulted);
            }
            Console.ReadLine();
        }
        static Task<string> DoWorkAsync()
        {
            return Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                return "Hello world...";
            });
        }
    }
}
