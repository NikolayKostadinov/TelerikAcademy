using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalsCommon
{
    public class Kittens : Cats
    {
        public Kittens(string name, short age) : base(name, age, Sex.Female) 
        { 
        }
        public override string ProduceSound()
        {
            return "Miau Miau";
        }
    }
}
