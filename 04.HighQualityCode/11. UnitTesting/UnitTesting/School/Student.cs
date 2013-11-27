//-----------------------------------------------------------------------
// <copyright file="Student.cs" company="Manhattan Inc.">
//     Manhattan Inc.
// </copyright>
//-----------------------------------------------------------------------
namespace School
{
    using System;

    /// <summary>
    /// Students Class
    /// </summary>
    public class Student : ICloneable
    {
        /// <summary>
        /// Student name
        /// </summary>
        private string name = string.Empty;

        /// <summary>
        /// Student id
        /// </summary>
        private uint id = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student" /> class.
        /// </summary>
        /// <param name="name">Name of student which is obligatory</param>
        /// <param name="id">Id of student - must be between 10000 and 99999</param>
        public Student(string name, uint id) 
        {
            this.Name = name;
            this.Id = id;
        }

        /// <summary>
        /// Gets Name of student
        /// </summary>
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Cannot create student with empty name");
                }

                this.name = value; 
            }
        }

        /// <summary>
        /// Gets Id of student - must be between 10000 and 99999
        /// </summary>
        public uint Id
        {
            get 
            { 
                return this.id; 
            }

            private set 
            {
                if (10000 > value || value > 99999)
                {
                    throw new ArgumentException("Student Id must be between 10000 and 99999");
                }

                this.id = value; 
            }
        }

        public object Clone()
        {
            Student cloneStudent = new Student(this.Name, this.id);
            return cloneStudent;
        }

        public override string ToString()
        {
            return this.Id + "; " + this.Name;
        }
    }
}
