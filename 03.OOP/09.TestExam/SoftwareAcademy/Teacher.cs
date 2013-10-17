using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private readonly IList<ICourse> courses = new List<ICourse>();
        private string name;

        public Teacher(string name)
        {
            this.Name = name;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format("Invalid entrye for {0}.Name", this.GetType().Name));
                }
                this.name = value;
            }
        }        

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Teacher: Name={0}; ", this.Name));

            int courseNumber = courses.Count;

            if (courseNumber == 0)
            {
                return sb.ToString();
            }
            else 
            {
                sb.Append("Courses=[");
            }

            int ix = 0;
            foreach (var course in this.courses)
            {
                ix++;
                if (ix < courseNumber)
                {
                    sb.Append(course.Name + ", ");
                }
                else 
                {
                    sb.Append(course.Name + "]");
                }
            }
            //sb.Append("\r\n");
            return sb.ToString();            
        }
    }
}
