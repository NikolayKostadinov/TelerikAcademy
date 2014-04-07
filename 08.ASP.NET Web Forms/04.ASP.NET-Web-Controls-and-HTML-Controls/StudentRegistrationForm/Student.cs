namespace StudentRegistrationForm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string university;
        private string facultyNumber;
        private IList<string> courses;

        /// <summary>
        /// Gets or sets the faculty number.
        /// </summary>
        /// <value>The faculty number.</value>
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentNullException("FacultyNumber");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Faculty number must be atleast 5 numbers long.", new ArgumentOutOfRangeException("FacultyNumber"));
                }

                foreach (char chr in value) 
                {
                    if (chr < '0' || chr > '9')
                    {
                        throw new ArgumentOutOfRangeException("FacultyNumber");
                    }
                }

                this.facultyNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>The courses.</value>
        public IList<string> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("courses");
                }
                this.courses = value;
            }
        }

        /// <summary>
        /// Gets or sets the University university.
        /// </summary>
        /// <value>The University university.</value>
        public string University
        {
            get
            {
                return this.university;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentNullException("university");
                }

                this.university = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentNullException("LarstName");
                }

                this.lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentNullException("FirstName");
                }

                this.firstName = value;
            }
        }

        public override string ToString()
        {
            string stringrepResentation = string.Empty;

            stringrepResentation += "Student Name: ".MakeMessage("h2") +
                                    (this.firstName + " " + this.lastName).MakeMessage("p") +
                //string.Empty.MakeMessage("br") +
                                    "Faculty Number: ".MakeMessage("h2") +
                                    this.facultyNumber.MakeMessage("p") +
                //string.Empty.MakeMessage("br") +
                                    "University: ".MakeMessage("h2") +
                                    this.university;//+
                                   // string.Empty.MakeMessage("br");

            if (this.courses != null)
            {
                stringrepResentation += "Registred Courses: ".MakeMessage("h2");

                foreach (var course in this.courses)
                {
                    stringrepResentation += course.MakeMessage("p"); //+
                                            //string.Empty.MakeMessage("br");
                }
            }

            return stringrepResentation;
        }
    }
}