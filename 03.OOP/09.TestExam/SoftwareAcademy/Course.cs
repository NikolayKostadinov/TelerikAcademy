using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;
        private readonly IList<string> topics = new List<string>();

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
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

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}: Name={1}; ", this.GetType().Name, this.Name));

            if (this.Teacher != null && !(string.IsNullOrEmpty(this.Teacher.Name) || string.IsNullOrWhiteSpace(this.Teacher.Name)))
            {
                sb.Append(string.Format("Teacher={0}; ", this.Teacher.Name));
            }

            int topicsNumber = this.topics.Count;

            if (topicsNumber == 0)
            {
                return sb.ToString();
            }
            else
            {
                sb.Append("Topics=[");
            }

            int ix = 0;
            foreach (var topic in this.topics)
            {
                ix++;
                if (ix < topicsNumber)
                {
                    sb.Append(topic + ", ");
                }
                else
                {
                    sb.Append(topic + "]; ");
                }
            }

            return sb.ToString();
        }
    }
}
