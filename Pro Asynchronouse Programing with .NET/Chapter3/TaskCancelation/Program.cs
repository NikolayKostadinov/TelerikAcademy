using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancelation
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            try
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                var ct = cts.Token;
                begin = DateTime.Now;
                var result = TimeOut(ct);

                int i = 0;
                var Chars = new List<char> { '/', '-', '\\', '|' };
                while (!result.IsCompleted) 
                {
                    i++;
                    Console.CursorTop = 0;
                    Console.CursorLeft = 0;
                    Console.Write(Chars[i % 4]);
                    Thread.Sleep(100);
                }

                Console.WriteLine(result.Result + " at {0} sec.", DateTime.Now - begin);
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.Flatten().InnerExceptions)
                {
                    if (exception.GetType() == typeof(TaskCanceledException) &&
                        ((TaskCanceledException)exception).CancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation was canceled successfully at {0} sec.", DateTime.Now - begin);
                    }                    
                }
            }
        }

        private static Task<string> TimeOut(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            return Task.Factory.StartNew(() =>
            {

                for (int i = 0; i < 10; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    Thread.Sleep(200);
                }
                return "TimeOut complete successfully.";
            }, ct);
        }
    }
}
