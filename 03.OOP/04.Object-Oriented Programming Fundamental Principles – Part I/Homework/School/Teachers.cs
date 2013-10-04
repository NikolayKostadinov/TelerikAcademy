namespace School
{
    using System;
    using System.Collections.Generic;

    public class Teachers : People
    {
        public Teachers(string name, string comment = "") : base(name, comment)
        {
            throw new System.NotImplementedException();
        }
    
        public List<Discipline> Disciplines
        {
            get
            {
                return this.Disciplines;
            }

            set
            {
                this.Disciplines = value;
            }
        }
    }
}
