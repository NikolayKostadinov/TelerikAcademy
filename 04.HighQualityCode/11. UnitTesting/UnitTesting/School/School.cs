//-----------------------------------------------------------------------
// <copyright file="School.cs" company="Manhattan Inc.">
//     Manhattan Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace School
{
    using System;
using System.Collections.Generic;

    /// <summary>
    /// School Class
    /// </summary>
    public class School
    {
        private string name = string.Empty;
        private uint lastStudentId = 10000;
        private List<Course> courses = new List<Course>();

        /// <summary>
        /// Initializes a new instance of the <see cref="School" /> class.
        /// </summary>
        /// <param name="name">Name of School</param>
        public School(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or Sets Name of school
        /// </summary>
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            private set 
            { 
                this.name = value; 
            }
        }

        /// <summary>
        /// Gets next available Student Id
        /// </summary>
        public uint GetStugentId
        {
            get 
            {
                return this.lastStudentId++;
            }
        }

        /// <summary>
        /// Adds new course in school
        /// </summary>
        /// <param name="course">Course to add</param>
        public void AddCourse(Course course) 
        {
            if (course == null) 
            {
                throw new ArgumentException("Course cannot be empty");
            }

            this.courses.Add(course);
        }

        public List<Course> ViewCourses() 
        {
            return this.courses;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
