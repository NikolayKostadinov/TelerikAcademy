using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalsCommon
{
    public class Dogs : Animals
    {
        public Dogs(string name, short age, Sex sex) : base(name, age, sex) { }
        public override string ProduceSound()
        {
            return "Bau Bau";
        }
    }
}
