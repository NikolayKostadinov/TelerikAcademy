using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab) : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get 
            {
                return this.lab;
            }
            
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format("Invalid entrye for {0}.Lab", this.GetType().Name));
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(string.Format("Lab={0}", this.Lab));
            return sb.ToString();
        }
    }
}
