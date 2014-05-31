using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Domain
{
    public interface IUnit
    {
        int Id { get; set; }

        string Code { get; set; }

        Measure Name { get; set; }

        double Value { get; set; }

        bool isByte { get; set; }
    }
}
