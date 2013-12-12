namespace PrintCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Student : IComparable<Student>
    {
        private string name = string.Empty;
        private string family = string.Empty;

        public Student(string name, string family) 
        {
            this.Name = name;
            this.Family = family;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Student's name cannot be an empty string.");
                }

                this.name = value;
            }
        }

        public string Family
        {
            get
            {
                return this.family;
            }
            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Student's family cannot be an empty string.");
                }

                this.family = value;
            }
        }

        public int CompareTo(Student other)
        {
            int compareValue = this.Family.CompareTo(other.Family);
            if (compareValue == 0)
            {
                compareValue = this.Name.CompareTo(other.Name);
                return compareValue;
            }
            else
            {
                return compareValue;
            }
        }

        public override string ToString()
        {
            return this.Name + " " + this.Family;
        }
    }
}
