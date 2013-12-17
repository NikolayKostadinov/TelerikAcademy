using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generation01Vector
{
    class Program
    {
        static void Main()
        {
            List<StringBuilder> result = new List<StringBuilder>();
            int n = 8;
            Generation01Vector(new int[n], 0, result);
            int i = 0;

            foreach (StringBuilder vector in result)
            {
                Console.Write("{0,3}  ",i);
                Console.WriteLine(vector);
                i++;
            }
        }

        private static void Generation01Vector(int[] vectors
            , int currentIndex, List<StringBuilder> result)
        {

            if (currentIndex == vectors.Length)
            {
                result.Add(new StringBuilder(string.Join("",vectors)));
                return;
            }

            vectors[currentIndex] = 0;
            Generation01Vector(vectors, currentIndex + 1, result);

            vectors[currentIndex] = 1;
            Generation01Vector(vectors, currentIndex + 1, result);
        }
    }
}
