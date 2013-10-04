using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MaxSequenceGreater
{
    class MaxSequenceGreater
    {
        static void Main(string[] args)
        {
            int[] sequence = { 2, 2, 4, 1, 3, 2, 3, 4};
            int maxPosition = 0;
            int maxLenght = 1;
            int currentPosition = 0;
            int currentLenght = 1;

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i - 1] < sequence[i])
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
