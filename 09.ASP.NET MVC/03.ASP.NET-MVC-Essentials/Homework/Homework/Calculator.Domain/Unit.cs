using System;

namespace Calculator.Domain
{
    public class Unit:IUnit
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public Measure Name { get; set; }

        public double Value { get; set; }

        public bool isByte { get { return (int)Name > 9; } }

        public override string ToString()
        {
            return string.Format("Id - {0}; Code - {1}; Name - {2} Value - {3}; IsByte-{4}", Id, Code, Name, Value, isByte);
        }
    }
}