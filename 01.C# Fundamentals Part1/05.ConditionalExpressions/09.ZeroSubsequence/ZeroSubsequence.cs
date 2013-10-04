using System;
using InputFunction; 

// TODO: 09. Дадени са пет цели числа. Напишете програма, която намира онези подмножества от тях, които имат сума 0. Примери:
//- Ако са дадени числата {3, -2, 1, 1, 8}, сумата на -2, 1 и 1 е 0.
//- Ако са дадени числата {3, 1, -7, 35, 22}, няма подмножества със сума 0.

    class ZeroSubsequence
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = new int[5];
            int counterOfCombinations = 0;
            try
            {
                for (int i = 0; i < inputNumbers.Length; i++)
                {
                    inputNumbers[i] = ConsoleInput.GetIntFromConsole("Enter the " 
                        + (i + 1) + 
                        ((i + 1) == 1 ? "st" : 
                        (i + 1) == 2 ? "nd" : 
                        (i + 1) == 3 ? "rd" : "th") + 
                        " number: ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            for (int i = 1; i < (int)(Math.Pow(2,inputNumbers.Length )); i++)
            {
                int sum = 0;
                string result = "";

                for (int j = 0; j < inputNumbers.Length; j++)
                {
                    int selection = ((i >> j) & 1);
                    int selectedNumber = inputNumbers[j] * selection; 
                    sum += selectedNumber;

                    if (selection > 0)
                    {
                        result += selectedNumber + " ";   
                    }
                }

                if (sum == 0)
                {
                    Console.WriteLine("The sum of " + result + "is zero!");
                    counterOfCombinations++;
                }
            }

            Console.WriteLine("There " + (counterOfCombinations > 1 ? "are " : "is ") + 
                counterOfCombinations + (counterOfCombinations > 1 ? " subsequences " : " subsequence ") + 
                "which sum is 0.");                
        }
    }