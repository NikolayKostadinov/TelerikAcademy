namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Student
    {
        private string firstName;
        private string lastName;
        private int grade;
        private int age;
        private ICollection<Mark> marks;

        public Student() 
        {
            this.marks = new HashSet<Mark>();
        }

        public int StudentId { get; set; }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
       
        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        //public int SchoolId { get; set; }

        public School School { get; set; }

        public virtual ICollection<Mark> Marks 
        {
            get { return this.marks; }
            set { this.marks = value; }
        }
    }
}
