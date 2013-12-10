namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryHeap<T>
        where T : IComparable<T>
    {
        private const int BaseOfHeap = 0;

        private List<T> binaryHeapContainer = new List<T>(1);

        public int Lenght 
        {
            get 
            {
                return this.binaryHeapContainer.Count;
            }
        }

        public T Root
        {
            get
            {
                return this.binaryHeapContainer[BaseOfHeap];
            }

            private set
            {
                if (this.binaryHeapContainer == null)
                {
                    throw new ArgumentException("The Binary Tree is not initialized!");
                }

                this.binaryHeapContainer[BaseOfHeap] = value;
            }
        }

        public T LeftChild(int parentIndex)
        {
            this.CheckIfNodeExist(parentIndex);
            int leftChildIndex = (2 * parentIndex) + 1;
            var leftChild = this.GetNode(leftChildIndex, "Left Node");
            return leftChild;
        }

        public T GetRightChild(int parentIndex)
        {
            this.CheckIfNodeExist(parentIndex);
            int rightChildIndex = (2 * parentIndex) + 2;
            var rightChild = this.GetNode(rightChildIndex, "Right Node");
            return rightChild;
        }

        public T GetParentNode(int childIndex)
        {
            int parentNodeIndex = (int)Math.Abs((double)(childIndex - 1) / 2);
            this.CheckIfNodeExist(parentNodeIndex);
            var parentNode = this.GetNode(parentNodeIndex, "Parent Node");
            return parentNode;
        }

        public void AddNode(T value)
        {
            this.binaryHeapContainer.Add(value);
            this.HeapSort();
        }

        public void RemoveRoot(int nodeIndex) 
        {
            if (this.binaryHeapContainer.Count == 0)
            {
                throw new NullReferenceException("Cannot remove element from the empty bynary heap!!!");
            }

            if (this.binaryHeapContainer.Count == 1) 
            {
                this.binaryHeapContainer.RemoveAt(BaseOfHeap);
            }

            this.SwapRecords(BaseOfHeap, this.binaryHeapContainer.Count - 1);
            this.binaryHeapContainer.RemoveAt(this.binaryHeapContainer.Count - 1);
            this.HeapSort();
        }

        private T GetNode(int childIndex, string nodeName)
        {
            if (childIndex <= (this.binaryHeapContainer.Count - 1))
            {
                return this.binaryHeapContainer[childIndex];
            }
            else
            {
                string message = string.Format("Asked {0} with id {1} is outside of heap boundaries.", nodeName, childIndex);
                throw new IndexOutOfRangeException(message);
            }
        }

        private void CheckIfNodeExist(int nodeIndex)
        {
            if (nodeIndex < 0 || nodeIndex > this.binaryHeapContainer.Count)
            {
                string message = string.Format("There is no node with id {0}!", nodeIndex);
                throw new IndexOutOfRangeException(message);
            }
        }

        private void HeapSort()
        {
            this.Heapify();

            int end = this.binaryHeapContainer.Count - 1;

            while (end > 0)
            {
                this.SwapRecords(end, BaseOfHeap);
                end--;
                this.ShiftDown(BaseOfHeap, end);
            }
        }

        private void Heapify()
        {
            int startIndex = (this.binaryHeapContainer.Count - 2) / 2;

            while (startIndex >= 0)
            {
                this.ShiftDown(startIndex, this.binaryHeapContainer.Count - 1);
                startIndex--;
            }
        }

        private void ShiftDown(int startIndex, int endIndex)
        {
            int root = startIndex;
            int child;
            int swap;

            while ((root * 2) + 1 <= endIndex)
            {
                child = (root * 2) + 1;
                swap = root;

                if (this.binaryHeapContainer[swap].CompareTo(this.binaryHeapContainer[child]) > 0)
                {
                    swap = child;
                }

                if (child + 1 <= endIndex && this.binaryHeapContainer[swap].CompareTo(this.binaryHeapContainer[child + 1]) > 0)
                {
                    swap = child + 1;
                }

                if (swap != root)
                {
                    this.SwapRecords(root, swap);
                    root = swap;
                }
                else
                {
                    return;
                }
            }
        }

        private void SwapRecords(int node1, int node2)
        {
            var swapBuffer = this.binaryHeapContainer[node2];
            this.binaryHeapContainer[node2] = this.binaryHeapContainer[node1];
            this.binaryHeapContainer[node1] = swapBuffer;
        }
    }
}
