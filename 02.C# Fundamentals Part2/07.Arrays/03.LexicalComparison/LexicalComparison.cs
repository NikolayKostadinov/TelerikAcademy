using System;

namespace _03.LexicalComparison
{
    class LexicalComparison
    {
        static void Main()
        {
            while (true)
            {
                bool firstIsLower = true;
                bool firstIsSmaller = true;
                bool isEqual = false;

                Console.Write("Enter first string: ");
                char[] firstString = Console.ReadLine().ToCharArray();
               
                if (new string(firstString) == "-1") return;

                Console.Write("Enter second string: ");
                char[] secondString = Console.ReadLine().ToCharArray();
                int lenghtOfSmaller = 0;

                if (firstString.Length < secondString.Length)
                {
                    lenghtOfSmaller = firstString.Length;
                    firstIsSmaller = true;
                }
                else if (firstString.Length == secondString.Length)
                {
                    lenghtOfSmaller = firstString.Length;
                    isEqual = true;
                    firstIsSmaller = false;
                }
                else
                {
                    lenghtOfSmaller = secondString.Length;
                    firstIsSmaller = false;
                }

                for (int i = 0; i < lenghtOfSmaller; i++)
                {
                    if (firstString[i] == secondString[i])
                    {
                        if (firstString.Length < secondString.Length)
                        {
                            firstIsLower = true;
                            isEqual = false;
                        }
                        else
                        {
                            firstIsLower = false;
                        }

                    }
                    else if (firstString[i] < secondString[i])
                    {
                        firstIsLower = true;
                        break;
                    }
                    else
                    {
                        firstIsLower = false;
                        isEqual = false;
                        break;
                    }
                }

                   
                if (firstIsLower)
                {
                    Console.WriteLine("{0} < {1}", new string(firstString), new string(secondString));
                }
                else if (!firstIsLower && !isEqual)
                {
                    Console.WriteLine("{0} < {1}", new string(secondString), new string(firstString));
                }
                else
                {
                    Console.WriteLine("{0} = {1}", new string(firstString), new string(secondString));
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
