using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town) : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        { 
            get
            {
                return this.town;
            } 
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format("Invalid entrye for {0}.Town", this.GetType().Name));
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(string.Format("Town={0}", this.Town));
            return sb.ToString();
        }
    }
}
