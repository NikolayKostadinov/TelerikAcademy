namespace PersonCommon
{
    using System;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name, int age) 
            : this(name)
        {
            this.Age = age;
        }

        public Person(string name)
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of Person must be specified");  
                }

                this.name = value; 
            }
        }

        public int? Age
        {
            get 
            {
                return this.age; 
            }
            
            set 
            { 
                this.age = value; 
            }
        }

        public override string ToString()
        {
            return string.Format("Pesson name: {0}; \r\n Person Age: {1}", this.Name, (this.Age == null) ? "age is not specified" : this.Age.ToString()); 
        }
    }
}
