namespace UtilityClasses
{
    using System;

    public class Student : Human
    {
        private float grade;

        public Student(string firstName, string lastName, float grade) 
            : base(firstName, lastName) 
        {
            this.Grade = grade;
        }

        public float Grade
        {
            get 
            {
                return this.grade;
            }

            private set 
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("The Value must be between 2 and 6");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "|{0,4}|{1,15}|{2,15}|",
                this.Grade,
                this.FirstName,
                this.LastName);
        }
    }
}
