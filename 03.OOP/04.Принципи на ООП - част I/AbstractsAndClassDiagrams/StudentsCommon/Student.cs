namespace StudentsCommon
{
    using System;

    public class Student : People
    {
        public Student(string name) : base(name)
        {
        }

        public override string Speak()
        {
            return this.Name + " says. I'm Drunken Student!!!";
        }
    }
}
