namespace AnimalsCommon
{
    using System;

    public abstract class Animals : ISound
    {
        private string name;
        private short age;

        public Animals(string name, short age, Sex sex)
        {
            this.Name = name;
            this.Age = age; 
            this.Sex = sex;
        }

        public Animals() : this(string.Empty, 0, Sex.Male) 
        {
        }
        
        public short Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
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
                    throw new ArgumentOutOfRangeException(
                        "Fied Name can't be empty.", 
                        new ArgumentOutOfRangeException());
                }

                this.name = value;
            }
        }

        public Sex Sex { get; set; }

        public abstract string ProduceSound();

        public void DisplaySound()
        {
            Console.WriteLine(
                string.Format(
                "{0} years old {1} {2} says - {3}", 
                this.Age, 
                this.ToString(), 
                this.Name, 
                this.ProduceSound()));
        }
    }
}
