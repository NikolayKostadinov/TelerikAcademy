namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var record in this.items)
            {
                if (record.CompareTo(item) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            return BiSearch(item, 0, this.items.Count);
        }

        private bool BiSearch(T item, int begin, int end)
        {
            if (end - begin < 1)
            {
                if (this.Items[begin].CompareTo(item) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int middleIndex = begin+((end - begin) / 2);
                if (this.Items[middleIndex].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.Items[middleIndex].CompareTo(item) > 0)
                {
                    return this.BiSearch(item, begin, middleIndex);
                }
                else 
                {
                    return this.BiSearch(item, middleIndex, end);
                }
            }
        }

        public void Shuffle()
        {
            // TODO : Write Shuffle
            //throw new NotImplementedException();
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
