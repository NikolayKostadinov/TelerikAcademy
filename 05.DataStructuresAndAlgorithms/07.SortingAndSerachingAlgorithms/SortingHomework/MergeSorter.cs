namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count > 1)
            {
                var sortedCollection = this.MergeSort(collection);

                int i = 0;
                foreach (var item in sortedCollection)
                {
                    collection[i] = item;
                    i++;
                }
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }
            else
            {
                var middleOfcollection = collection.Count / 2;
                var left = new List<T>(middleOfcollection);
                var right = new List<T>(collection.Count - middleOfcollection);

                for (int index = 0; index < middleOfcollection; index++)
                {
                    left.Add(collection[index]);
                }

                for (int index = middleOfcollection; index < collection.Count; index++)
                {
                    right.Add(collection[index]);
                }

                left = this.MergeSort(left) as List<T>;
                right = this.MergeSort(right) as List<T>;
                
                IList<T> result = this.Merge(left, right);

                return result;
            }
        }

        public IList<T> Merge(IList<T> leftList, IList<T> rightList)
        {
            IList<T> result = new List<T>();
            int indexLeft = 0;
            int indexRight = 0;
            while (indexLeft < leftList.Count || indexRight < rightList.Count)
            {
                if (indexLeft < leftList.Count && indexRight < rightList.Count)
                {
                    if (leftList[indexLeft].CompareTo(rightList[indexRight]) > 0)
                    {
                        result.Add(rightList[indexRight]);
                        indexRight++;
                    }
                    else
                    {
                        result.Add(leftList[indexLeft]);
                        indexLeft++;
                    }
                }
                else if (indexLeft < leftList.Count)
                {
                    result.Add(leftList[indexLeft]);
                    indexLeft++;
                }
                else if (indexRight < rightList.Count)
                {
                    result.Add(rightList[indexRight]);
                    indexRight++;
                }
            }

            return result;
        }
    }
}
