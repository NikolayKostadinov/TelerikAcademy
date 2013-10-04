namespace AnimalsCommon
{
    using System;

    public class Kittens : Cats
    {
        public Kittens(string name, short age) : base(name, age, Sex.Female) 
        { 
        }

        public override string ProduceSound()
        {
            return "Miau Miau";
        }

        public override string ToString()
        {
            return "kitten";
        }
    }
}
