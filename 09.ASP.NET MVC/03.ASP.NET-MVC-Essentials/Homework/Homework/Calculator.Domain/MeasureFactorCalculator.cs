using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Domain
{
    public static class MeasureFactorCalculator
    {
        /// <summary>
        /// Calculates the factor.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        public static double CalculateFactor(this IUnit unit, KiloMultiplier multiplier)
        {
            int unitPowValue = (int)unit.Name;
            int multiplierValue = (int)multiplier;
            double factor = Math.Pow(multiplierValue, unitPowValue) * (unit.isByte ? 1 : 8);
            return factor;
        }
    }
}
