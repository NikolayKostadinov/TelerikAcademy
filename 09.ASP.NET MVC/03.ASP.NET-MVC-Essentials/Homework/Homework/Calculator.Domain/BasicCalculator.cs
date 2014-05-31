using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Domain
{
    public class BasicCalculator : ICalculator
    {
        private double baseValue = 8388608;

        public BasicCalculator(double baseValue) 
        {
            this.baseValue = baseValue;
        }
        
        public void CalculateValue(IUnit unit, double factor)
        {
            unit.Value = baseValue * (unit.isByte ? 1 : 8) * factor;
        }
    }
}
