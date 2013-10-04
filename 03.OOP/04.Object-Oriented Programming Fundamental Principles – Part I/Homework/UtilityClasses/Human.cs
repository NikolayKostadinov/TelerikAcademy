namespace UtilityClasses
{
    using System;

    public abstract class Human 
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName 
        { 
            get
            {
                return this.firstName;
            }

            private set 
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentOutOfRangeException(
                        "FirstName cannot be empty !!!", 
                        new ArgumentOutOfRangeException());
                }

                this.firstName = value;
            }
        }

        public string LastName 
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentOutOfRangeException(
                        "LastName cannot be empty !!!",
                        new ArgumentOutOfRangeException());
                }

                this.lastName = value;
            }
        }

        public abstract override string ToString();

        public void WriteMe()
        {
            Console.WriteLine(
                this.GetType().ToString().Substring(
                this.GetType().ToString().IndexOf('.') + 1) + " " + this.ToString());
        }
    }
}