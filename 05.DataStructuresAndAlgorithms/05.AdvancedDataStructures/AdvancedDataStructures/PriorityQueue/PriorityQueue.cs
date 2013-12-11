namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private BinaryHeap<T> dataContainer = new BinaryHeap<T>();

        public PriorityQueue()
            : base() 
        { 
        }

        public PriorityQueue(List<T> inputList)
            : base()
        {
            if (inputList.Count > 0)
            {
                foreach (var record in inputList)
                {
                    this.dataContainer.AddNode(record);
                }
            }
        }

        public int Lenght 
        {
            get 
            {
                return this.dataContainer.Lenght;
            }
        }

        public void Enqueue(T value) 
        {
            this.dataContainer.AddNode(value);
        }

        public T Dequeue() 
        {
            T root = this.dataContainer.Root;
            this.dataContainer.RemoveRoot();
            return root;
        }
    }
}
