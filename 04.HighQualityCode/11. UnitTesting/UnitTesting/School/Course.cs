//-----------------------------------------------------------------------
// <copyright file="Course.cs" company="Manhattan Inc.">
//     Manhattan Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace School
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Course Class
    /// </summary>
    public class Course : ICloneable
    {
        private string name = string.Empty;
        private Dictionary<uint, Student> students = new Dictionary<uint, Student>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Course" /> class.
        /// </summary>
        /// <param name="name">Name of Course</param>
        public Course(string name) 
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or Sets Name of Course
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
        /// Deep copy of Course object
        /// </summary>
        /// <returns>New Course object</returns>
        public object Clone()
        {
            Course cloneCourse = new Course(this.Name);
            foreach (var student in this.students) 
            {
                Student st = (Student)student.Value.Clone();
                cloneCourse.JoinCourse(st);
            }

            return cloneCourse;
        }

        /// <summary>
        /// Join Student to course
        /// </summary>
        /// <param name="student">Student to join</param>
        public void JoinCourse(Student student) 
        {
            if (student == null)
            {
                throw new ArgumentException("Student cannot be empty!!!");
            }

            if (this.students.Count >= 30)
            {
                throw new IndexOutOfRangeException("There cannot be more than 30 students in this course!!!");
            }

            if (this.students.ContainsKey(student.Id))
            {
                string message = string.Format(
                    "The Student with id {0}  is allready joined to this course!!!",
                    student.Id);
                throw new ArgumentException(message);
            }

            this.students.Add(student.Id, student);
        }

        /// <summary>
        /// Removes student from Course
        /// </summary>
        /// <param name="student">Student to remove</param>
        public void LeaveCourse(Student student) 
        {
            if (student == null)
            {
                throw new ArgumentException("Student cannot be empty!!!");
            }

            if (this.students.Count == 0)
            {
                throw new IndexOutOfRangeException("There cannot be less than 0 students in this course!!!");
            }

            if (this.students.ContainsKey(student.Id))
            {
                this.students.Remove(student.Id);
            }
            else 
            {
                string message = string.Format(
                    "The Student with id {0} wasn't join to this course!!!",
                    student.Id);
                throw new ArgumentException(message);
            }  
        }

        public Dictionary<uint, Student> ViewStudents()
        {
            Dictionary<uint, Student> cloneStudents = new Dictionary<uint, Student>(this.students.Count);

            foreach (var student in this.students)
            {
                Student st = (Student)student.Value.Clone();
                cloneStudents.Add(st.Id, st);
            }

            return cloneStudents;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
