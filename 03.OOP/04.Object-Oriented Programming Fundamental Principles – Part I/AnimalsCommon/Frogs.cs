using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalsCommon
{
    public class Frogs : Animals
    {
        public Frogs(string name, short age, Sex sex) : base(name, age, sex) { }
        public override string ProduceSound()
        {
            return "Quak Quak";
        }
    }
}
