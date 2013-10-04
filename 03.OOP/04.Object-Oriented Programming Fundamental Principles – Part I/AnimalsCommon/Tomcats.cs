namespace AnimalsCommon
{
    using System;

    public class Tomcats : Cats
    {
        public Tomcats(string name, short age) : base(name, age, Sex.Male)
    {
    } 
        public override string ProduceSound()
        {
            return "Yrrr Yrrr";
        }
    }
}
