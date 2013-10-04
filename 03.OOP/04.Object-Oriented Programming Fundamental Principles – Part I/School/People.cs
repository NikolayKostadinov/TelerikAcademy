namespace School
{
    using System;

    public abstract class People : Comments
    {
        private string name;

        public People(string name, string comment = "") 
            : base(comment)
        {
            this.Name = name;
        }
    
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentOutOfRangeException(
                        "Name can't be empty!!", 
                        new ArgumentOutOfRangeException()); 
                }
                
                this.name = value;
            }
        }
    }
}
