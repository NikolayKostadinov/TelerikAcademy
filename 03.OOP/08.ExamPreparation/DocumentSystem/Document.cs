namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Document : IDocument
    {
        public string Name
        {
            get
            {
                return this.GetProperty("Name") as string;
            }

            set
            {
                this.LoadProperty("Name", value.ToString());
            }
        }

        public string Content
        {
            get
            {
                return this.GetProperty("Content").ToString();
            }

            set
            {
                this.LoadProperty("Content", value.ToString());
            }
        }
       
        protected readonly Dictionary<string, object> properties 
            = new Dictionary<string, object>();

        public void LoadProperty(string key, string value)
        {
            if (this.properties.ContainsKey(key.ToLower()))
            {
                this.properties[key] = value;
            }
            else
            {
                this.properties.Add(key.ToLower(), value);
            }
        }

        public void SaveAllProperties(out IList<KeyValuePair<string, object>> output)
        {
            output = this.properties.ToList();
            output = output.OrderBy(x => x.Key).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append('[');
            
            IList<KeyValuePair<string,object>>props ;//= new List<KeyValuePair<string,object>>();

            this.SaveAllProperties(out props);

            foreach (var item in props)
            {
                if (item.Value != null)
                {
                    sb.AppendFormat("{0}={1};", item.Key.ToString(), item.Value.ToString()); 
                }
            }

            return sb.ToString().Trim(';') + "]";
        }

        protected object GetProperty(string key) 
        {
            if (this.properties.ContainsKey(key.ToLower()))
            {
                return properties[key.ToLower()];
            }
            else
            {
                return null;
            }
        }
    }
}

