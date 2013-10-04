namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Class : Comments
    {
        private string id;

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException(
                        "Class Id cannot be empty!!!", 
                        new ArgumentOutOfRangeException()); 
                }

                this.id = value;
            }
        }

        public List<Teachers> Teachers
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
