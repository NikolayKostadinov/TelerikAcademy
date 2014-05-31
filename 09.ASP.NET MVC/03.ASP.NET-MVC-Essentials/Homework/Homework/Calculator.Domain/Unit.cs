using System;

namespace Calculator.Domain
{
    public class Unit:IUnit
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public Measure Name { get; set; }

        public double Value { get; set; }

        public bool isByte { get; set; }
    }
}