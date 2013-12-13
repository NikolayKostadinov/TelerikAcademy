namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private Random randomGenerator = new Random();

        public void Sort(IList<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private int Partition(IList<T> partitionedList, int leftIndex, int rightIndex, int pivotIndex)
        {
            T pivotValue = partitionedList[pivotIndex];
            Swap(partitionedList, pivotIndex, rightIndex);  // преместваме "главния" елемент в края
            int storeIndex = leftIndex;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (partitionedList[i].CompareTo(pivotValue) < 0)
                {
                    Swap(partitionedList, i, storeIndex);
                    storeIndex = storeIndex + 1;
                }
            }
            Swap(partitionedList, storeIndex, rightIndex);  // преместваме "главния" елемент на финалната му позиция
            return storeIndex;
        }

        private void Swap(IList<T> list, int sourceIndex, int destinationIndex)
        {
            T oldValue = list[sourceIndex];
            list[sourceIndex] = list[destinationIndex];
            list[destinationIndex] = oldValue;
        }

        private void Quicksort(IList<T> array, int left, int right)
        {
            // ако списъкът има два или повече елемента
            if (left < right)
            {
                // Вижте секцията "Избор на главен елемент" по-долу за възможните варианти
                // choose any pivotIndex such that left ≤ pivotIndex ≤ right
                int pivotIndex = left + (right - left) / 2;
                // Намерете списъците с по-малките и по-големите елементи, както и позицията на избрания главен елемент
                int pivotNewIndex = Partition(array, left, right, pivotIndex);

                // Рекурсивно сортирайте елементите, по-малки от главния елемент
                Quicksort(array, left, pivotNewIndex - 1);

                // Рекурсивно сортирайте елементите, по-малки или равни на главния елемент
                Quicksort(array, pivotNewIndex + 1, right);
            }
        }
    }
}
