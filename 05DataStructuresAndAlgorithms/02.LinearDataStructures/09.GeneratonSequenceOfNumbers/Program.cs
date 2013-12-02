namespace GeneratonSequenceOfNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int generatorBase = 2;
            List<long> generatedSequence = GeneratedSequence(generatorBase);
            Console.WriteLine("2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6,...");
            Console.WriteLine(string.Join(", ", generatedSequence));
        }

        /// <summary>
        /// S1 = N;  
        /// S2 = S1 + 1;
        /// S3 = 2*S1 + 1;
        /// S4 = S1 + 2;
        /// S5 = S2 + 1;
        /// S6 = 2*S2 + 1;
        /// S7 = S2 + 2;
        /// </summary>
        /// <returns>result</returns>
        private static List<long> GeneratedSequence(int generatorBase)
        {
            const int LenOfGeneratedList = 50;
            List<long> result = new List<long>(50);
            Queue<long> nextOperand = new Queue<long>();
            nextOperand.Enqueue(generatorBase);

            while (true)
            {
                long currentOperand = nextOperand.Dequeue();
                result.Add(currentOperand);

                if (result.Count == LenOfGeneratedList)
                {
                    break;   
                }

                nextOperand.Enqueue(currentOperand + 1);
                nextOperand.Enqueue(2*currentOperand + 1);
                nextOperand.Enqueue(currentOperand + 2);
            }

            return result;
        }
    }
}
