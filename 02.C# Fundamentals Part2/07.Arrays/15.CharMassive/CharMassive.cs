using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15.CharMassive
{
    class CharMassive
    {
        static void Main(string[] args)
        {
            List<char> alphabet = new List<char>(0);
            string inputString = Console.ReadLine(); 
            char counter = 'A';
            while(counter <= 'z')
            {
                alphabet.Add(counter);
                counter++;
            }

            counter = 'А';
            while (counter <= 'я')
            {
                alphabet.Add(counter);
                counter++;
            }

            foreach (char symbol in inputString)
            {
                Console.Write(alphabet.IndexOf(symbol) + " ");
            }

        }
    }
}
