namespace AnimalsCommon
{
    using System;

    public class Dogs : Animals
    {
        public Dogs(string name, short age, Sex sex) : base(name, age, sex) 
        {
        }

        public override string ProduceSound()
        {
            return "Bau Bau";
        }

        public override string ToString()
        {
            return "dog";
        }
    }
}
