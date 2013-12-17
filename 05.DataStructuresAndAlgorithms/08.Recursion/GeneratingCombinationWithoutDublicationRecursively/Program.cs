using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingCombinationWithoutDublicationRecursively
{
    class Program
    {
        static void Main()
        {
            List<string> names = new List<string>() 
            { "Presho", "Gosho", "Stoian", "Minka", "Ceca", "Meca", "Chicho", "Dicho" };

            int combinationBase = 3;

            CombinationGenerator<string> combinationGenerator = new CombinationGenerator<string>(combinationBase,names);

            List<string[]> result = combinationGenerator.ResultCombinations;

            foreach (var combination in result)
            {
                for (int i = 0; i < combinationBase; i++)
                {
                    if (i < combinationBase - 1)
                    {
                        Console.Write("{0,20}, ", combination[i]);
                    }
                    else
                    {
                        Console.WriteLine("{0,20}", combination[i]); 
                    }
                }                
            }
        }
    }
}
