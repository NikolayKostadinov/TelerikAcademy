using System;

namespace _02.EqualArrays
{
    class EqualArrays
    {
        static void Main()
        {
            bool isEqual = true;
            Console.Write("Enter the lenght of the first array: ");
            int arrayLenght1 = int.Parse(Console.ReadLine());
            int[] array1 = new int[arrayLenght1];

            for (int i = 0; i < arrayLenght1; i++)
            {
                Console.Write("Enter Arra1[{0}]: ", i);
                array1[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter the lenght of the second array: ");
            int arrayLenght2 = int.Parse(Console.ReadLine());
            int[] array2 = new int[arrayLenght2];

            for (int i = 0; i < arrayLenght2; i++)
            {
                Console.Write("Enter Arra2[{0}]: ", i);
                array2[i] = int.Parse(Console.ReadLine());
            }

            if (array1.Length == array2.Length)
            {
                for (int i = 0; i < array1.Length ; i++)
                {
                    if (array1[i] != array2[i])
                        isEqual = false;
                }
            }
            else
            {
                isEqual = false; 
            }

            Console.WriteLine(isEqual? "Two arrays are equal!":"Two arrays aren't equal!" );

        }
    }
}
