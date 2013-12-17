namespace GeneratingCombinationWithoutDublicationRecursively
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CombinationGenerator<T>
    {
        private int numberOfElements = 0;
        private List<T> valuesOfElements;
        private List<T[]> resultCombinations = new List<T[]>();


        public CombinationGenerator(int numberOfElements, List<T> valuesOfElements)
        {
            this.numberOfElements = numberOfElements;
            this.valuesOfElements = valuesOfElements;
        }

        public List<T[]> ResultCombinations
        {
            get
            {
                this.GetCombinations(0, 0, new T[numberOfElements], resultCombinations);
                return resultCombinations;
            }
        }

        private void GetCombinations(int currentIndex, int currentValueId,
            T[] resultCombination, List<T[]> resultCombinations)
        {
            if (currentIndex == resultCombination.Length)
            {
                T[] resBufer = new T[this.numberOfElements];
                resultCombination.CopyTo(resBufer, 0);
                resultCombinations.Add(resBufer);
                return;
            }

            for (int j = currentValueId; j < valuesOfElements.Count; j++)
            {
                resultCombination[currentIndex] = valuesOfElements[j];
                GetCombinations(currentIndex + 1, j + 1, resultCombination, resultCombinations);
            }
        }
    }
}
