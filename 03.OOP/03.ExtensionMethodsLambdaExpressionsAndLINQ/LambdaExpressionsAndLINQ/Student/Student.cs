namespace Student
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ushort Age { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        } 
    }
}
