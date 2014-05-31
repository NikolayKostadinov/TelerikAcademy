using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Domain
{
    public interface ICalculator
    {
        void CalculateValue(IUnit unit, double factor);
    }
}