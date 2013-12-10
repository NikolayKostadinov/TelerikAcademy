namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class BinaryHeap<T>
        where T: IComparable<T>
    {
        const int BaseOfHeap = 0;

        private List<T> binaryHeapContainer = new List<T>(1);
        
        public T Root
        {
            get 
            {
                return binaryHeapContainer[BaseOfHeap];
            }
            private set 
            {
                if (binaryHeapContainer == null) 
                {
                    throw new ArgumentException("The Binary Tree is not initialized!");
                }
                binaryHeapContainer[BaseOfHeap] = value;
            }
        }

        public T LeftChild(int parentIndex) 
        {
            CheckIfNodeExist(parentIndex);
            int leftChildIndex = (2*parentIndex) + 1;
            var leftChild = GetNode(leftChildIndex, "Left Node");
            return leftChild;
        }

        private void SetLeftChild(int parentIndex, T value) 
        {
            int leftChildIndex = (2 * parentIndex) + 1;
            AddChild(leftChildIndex, value);
        }

        public T GetRightChild(int parentIndex)
        {
            CheckIfNodeExist(parentIndex);
            int rightChildIndex = (2 * parentIndex) + 2;
            var rightChild = GetNode(rightChildIndex, "Right Node");
            return rightChild;
        }

        public T GetParentNode(int childIndex)
        {
            int parentNodeIndex = (int)Math.Abs((double)(childIndex - 1) / 2);
            CheckIfNodeExist(parentNodeIndex);
            var parentNode = GetNode(parentNodeIndex, "Parent Node");
            return parentNode;
        }

        private T GetNode(int childIndex, string nodeName)
        {

            if (childIndex <= (this.binaryHeapContainer.Count - 1))
            {
                return this.binaryHeapContainer[childIndex];
            }
            else
            {
                string message = string.Format("Asked {0} with id {1} is outside of heap boundaries.",
                    nodeName, childIndex);
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

        private void SetRightChild(int parentIndex, T value)
        {
            int rightChildIndex = (2 * parentIndex) + 2;
            AddChild(rightChildIndex, value);
        }

        private void AddChild(int childIndex, T value)
        {
            if (childIndex > this.binaryHeapContainer.Count - 1)
            {
                int numberOfRecordsToAdd = childIndex - (this.binaryHeapContainer.Count - 1);
                this.binaryHeapContainer.AddRange(new List<T>(numberOfRecordsToAdd));
            }

            this.binaryHeapContainer[childIndex] = value;
        }

        private void HeapSort() 
        {
            /* 
     function heapSort(a, count) is
     input:  an unordered array a of length count
 
     (first place a in max-heap order)
     heapify(a, count)
 
     end := count-1 //in languages with zero-based arrays the children are 2*i+1 and 2*i+2
     while end > 0 do
         (swap the root(maximum value) of the heap with the last element of the heap)
         swap(a[end], a[0])
         (decrease the size of the heap by one so that the previous max value will
         stay in its proper placement) 
         end := end - 1
         (put the heap back in max-heap order)
         siftDown(a, 0, end)          
 
 function heapify(a, count) is
     (start is assigned the index in a of the last parent node)
     start := (count - 2 ) / 2
     
     while start ≥ 0 do
         (sift down the node at index start to the proper place such that all nodes below
          the start index are in heap order)
         siftDown(a, start, count-1)
         start := start - 1
     (after sifting down the root all nodes/elements are in heap order)
 
 function siftDown(a, start, end) is
     input:  end represents the limit of how far down the heap
                   to sift.
     root := start

     while root * 2 + 1 ≤ end do          (While the root has at least one child)
         child := root * 2 + 1        (root*2 + 1 points to the left child)
         swap := root        (keeps track of child to swap with)
         (check if root is smaller than left child)
         if a[swap] < a[child]
             swap := child
         (check if right child exists, and if it's bigger than what we're currently swapping with)
         if child+1 ≤ end and a[swap] < a[child+1]
             swap := child + 1
         (check if we need to swap at all)
         if swap != root
             swap(a[root], a[swap])
             root := swap          (repeat to continue sifting down the child now)
         else
             return
             * /
        }
    }
}
