namespace BinaryHeapDemo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using PQ;

    internal class BinaryHeapDemo
    {
        private static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<int> inputList = new List<int>() { 1, 34, 5, 15, 250, 300, 22, 44, 52, 2, 34 };
            PriorityQueue.PriorityQueue<int> queue = new PriorityQueue.PriorityQueue<int>(inputList);
            queue.Enqueue(1000);
            
            while (queue.Lenght > 0)
            {
                int currentRecord = queue.Dequeue();
                Console.WriteLine(currentRecord);
            }

            sw.Stop();

            Console.WriteLine(sw.Elapsed);
            sw.Reset();

            sw.Start();

            PQ.PriorityQueue<int> queue1 = new PriorityQueue<int>();
            foreach (var item in inputList)
            {
                queue1.Enqueue(item);
            }

            queue1.Enqueue(1000);            

            while (queue1.Count > 0)
            {
                int currentRecord = queue1.Dequeue();
                Console.WriteLine(currentRecord);
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
