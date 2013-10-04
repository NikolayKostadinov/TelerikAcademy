namespace StudentsCommon
{
    using System;

    public abstract class People : ISpeakable
    {
        private string name;

        public People(string name)
        {
            this.name = name;
        }
    
        public string Name
        {
            get
            {
                return this.name;
            }

            set 
            {
                this.name = value;
            }
        }

        public int Mail
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Sex
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public abstract string Speak();

        public void PrintSpeach()
        {
            Console.WriteLine(this.Speak());
            Console.WriteLine();
        }
    }
}
