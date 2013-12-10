namespace BinaryHeapDemo
{
    using System;
    using PriorityQueue;

    internal class BinaryHeapDemo
    {
        private static void Main()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            Random randomGenerator = new Random();
            for (int i = 0; i < 10; i++)
            {
                binaryHeap.AddNode(randomGenerator.Next(100000));
            }

            Console.WriteLine(binaryHeap.Root);
            Console.WriteLine();
        }
    }
}
