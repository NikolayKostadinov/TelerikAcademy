namespace StudentsCommon
{
    using System;

    public class Employer : People
    {
        public Employer(string name) : base(name)
        {
        }
    
        public override string Speak()
        {
            return this.Name + "says - I'm greasy docker!!!";
        }
    }
}
