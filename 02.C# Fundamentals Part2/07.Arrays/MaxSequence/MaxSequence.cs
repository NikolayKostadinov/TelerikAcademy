using System;

namespace MaxSequence
{
    class MaxSequence
    {
        static void Main()
        {
            int[] sequence = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            int maxPosition = 0;
            int maxLenght = 1;
            int currentPosition = 0;
            int currentLenght = 1;
            
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i - 1] == sequence[i])
                {
                    currentLenght++; 
                }
                else
                {
                    currentLenght = 1;
                    currentPosition = i;
                }
                if (currentLenght > maxLenght)
                {
                    maxLenght = currentLenght;
                    maxPosition = currentPosition; 
                }
            }

            foreach (var item in sequence)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Maximal sequence is: ");

            for (int i = maxPosition; i < maxPosition + maxLenght; i++)
            {
                Console.Write(sequence[i] + " ");
            }

            Console.WriteLine();
        }
    }
}