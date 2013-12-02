namespace FindLongestSequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;

    public static class ListExtention
    {
        /// <summary>
        /// Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. 
        /// Write a program to test whether the method works correctly.
        /// </summary>
        /// <returns>Found Secuence</returns>
        public static List<int> GetMaximalSequenceOfEcual(this List<int> inputList )
        {
            if (0 >= inputList.Count && inputList.Count <= 1)
            {
                return inputList;
            }

            int maxSequenceMember = inputList[0];
            int maxSequenceLenght = 1;
            int currentSequenceLenght = 1;
            int previouseMember = maxSequenceMember;

            for (int i = 1; i < inputList.Count; i++)
            {
                if (previouseMember == inputList[i])
                {
                    currentSequenceLenght++;
                    if (currentSequenceLenght > maxSequenceLenght)
                    {
                        maxSequenceMember = inputList[i - 1];
                        maxSequenceLenght = currentSequenceLenght;
                    }
                }
                else
                {
                    previouseMember = inputList[i];
                    currentSequenceLenght = 1;
                }
            }

            List<int> maxSequence = GenerateMaxSequence(maxSequenceMember, maxSequenceLenght);
            return maxSequence;
        }

        private static List<int> GenerateMaxSequence(int maxSequenceMember, int maxSequenceLenght)
        {
            List<int> result = new List<int>(maxSequenceLenght);

            for (int i = 0; i < maxSequenceLenght; i++)
            {
                result.Add(maxSequenceMember);   
            }
            return result;
        }
    }
}
