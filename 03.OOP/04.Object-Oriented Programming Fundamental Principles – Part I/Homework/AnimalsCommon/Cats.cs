namespace AnimalsCommon
{
    using System;

    public abstract class Cats : Animals
    {
        public Cats(string name, short age, Sex sex) : base(name, age, sex) 
        { 
        } 
    }
}
