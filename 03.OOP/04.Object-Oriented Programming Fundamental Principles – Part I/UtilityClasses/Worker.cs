namespace UtilityClasses
{
    using System;

    public class Worker : Human
    {
        public Worker(string firstName, string lastName) 
            : this(firstName, lastName, 0m, 0) 
        { 
        }

        public Worker(string firstName, string lastName, decimal weekSalary, short workHoursPerDay) 
            : base(firstName, lastName) 
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary { get; set; }

        public short WorkHoursPerDay { get; set; }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
            return string.Format(
                "{0,15:C2}|{1,15}|{2,15}", 
                this.MoneyPerHour(), 
                this.FirstName, 
                this.LastName);
        }
    }
}
