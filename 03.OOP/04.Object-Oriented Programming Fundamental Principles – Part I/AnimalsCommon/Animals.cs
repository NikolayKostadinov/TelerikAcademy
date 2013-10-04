namespace AnimalsCommon
{
    using System;

    public abstract class Animals : ISound
    {
        private Sex sex;
        private string name;
        private int age;

        public Animals(string name, short age, Sex sex)
        {
            this.Name = name;
            this.Age = age; 
            this.Sex = sex;
        }

        public Animals() : this("", 0, Sex.Male) 
        {
        }
        
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException(
                        "Age must be between 0 and 200!!!", 
                        new ArgumentOutOfRangeException());
                }

                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("Fied Name can't be empty.", new ArgumentOutOfRangeException());
                }

                this.name = value;
            }
        }


        public Sex Sex 
        { 
            get
            {
                return this.sex;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentOutOfRangeException("Fied sex can't be empty.", new ArgumentOutOfRangeException());  
                }
                this.sex = value;
            }
        }

        public abstract string ProduceSound();
    }
}
