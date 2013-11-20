namespace Person
{
    using System;

    public class Program
    {
        internal enum Sex 
        { 
            Men, 
            Woman 
        }

        public void MakePerson(int personId)
        {
            Person newPerson = new Person();
            newPerson.Age = personId;
            if (personId % 2 == 0)
            {
                newPerson.Name = "Батката";
                newPerson.Sex = Sex.Men;
            }
            else
            {
                newPerson.Name = "Мацето";
                newPerson.Sex = Sex.Woman;
            }
        }

        internal class Person
        {
            public Sex Sex { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
