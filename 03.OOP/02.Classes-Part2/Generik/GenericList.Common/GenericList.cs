namespace GenericList.Common
{
    /* TODO: Write a generic class GenericList<T> that keeps a list of elements 
     * of some parametric type T. Keep the elements of the list in an array 
     * with fixed capacity which is given as parameter in the class constructor. 
     * Implement methods for adding element, accessing element by index, 
     * removing element by index, inserting element at given position, 
     * clearing the list, finding element by its value and ToString(). 
     * Check all input parameters to avoid accessing elements 
     * at invalid positions.*/

    using System;

    public class GenericList<T>
        where T : IComparable 
    {
        private T[] arr;
        private int lastIndex = 0;

        public GenericList(int arrSize)
        {
            if (arrSize < 0 | arrSize > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("arrSize");
            }

            this.arr = new T[arrSize];
        }

        public int Lenght
        {
            get
            {
                return this.lastIndex;
            }
        }

        public T this[int index]
        {
            get 
            {
                if (index < 0 | index >= this.arr.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                return this.arr[index];
            }

            set
            {
                if (index < 0 | index > this.arr.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                this.arr[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.lastIndex >= this.arr.Length)
            {
                this.AutogrowMe();
            }

            this.arr[this.lastIndex] = item;
            this.lastIndex++;
        }

        public void Remove(int index)
        {
            if (index < 0 | index >= this.arr.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (this.lastIndex == 0)
            {
                throw new ArgumentException("The array is empty.");
            }

            for (int i = this.arr.Length - 1; i > index; i--)
            {
                this.arr[i - 1] = this.arr[i];
            }

            this.arr[this.arr.Length - 1] = default(T);
            this.lastIndex--;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 | index >= this.arr.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (this.lastIndex == this.arr.Length)
            {
                this.AutogrowMe();
            }

            for (int i = this.lastIndex - 1; i >= index; i--)
            {
                this.arr[i + 1] = this.arr[i];
            }

            this.arr[index] = value;
            this.lastIndex++;
        }

        public void Clear() 
        {
            for (int i = 0; i < this.lastIndex; i++)
            {
                this.arr[i] = default(T);
            }

            this.lastIndex = 0;
        }

        public int Find(T item) 
        {
            for (int i = 0; i < this.lastIndex; i++)
            {
                if (this.arr[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
           return "Hi! That's me.";
        }

        private void AutogrowMe()
        {
            T[] arrTemp = new T[this.arr.Length * 2];
            for (int i = 0; i < this.arr.Length; i++)
            {
                arrTemp[i] = this.arr[i];
            }

            this.arr = arrTemp;
        }
    }
}
