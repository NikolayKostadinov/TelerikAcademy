namespace SchoolSystem.Models
{
    using System;
    using System.Linq;
    
    public class Mark
    {
        private decimal value;
        private string subject;
        public int MarkId { get; set; }

        public string Subject
        {
            get
            {
                return string.Copy(this.subject);
            }

            set 
            { 
                if (value == null || string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("The name of the subject can't be empty!");
                }

                this.subject = value;
            }
        }

        public decimal Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < 2m || value > 6m)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The value of the mark must be between 2 and 6.\nYou have entered {0}", value));
                }

                this.value = value;
            }
        }
    }
}
