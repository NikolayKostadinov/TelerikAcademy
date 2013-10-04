namespace AnimalsCommon
{
    using System;

    public class Frogs : Animals
    {
        public Frogs(string name, short age, Sex sex) : base(name, age, sex) 
        {
        }

        public override string ProduceSound()
        {
            return "Quak Quak";
        }

        public override string ToString()
        {
            return "frog";
        }
    }
}
