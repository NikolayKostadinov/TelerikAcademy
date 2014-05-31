using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain
{
    public class Measures
    {
        private static IEnumerable<IUnit> units;
        KiloMultiplier multiplier;
        static Measures() 
        {
            PopulateMeasures();
        }
        
        private static void PopulateMeasures()
        {
            units = new Unit[]
            {
                new Unit(){ Id = 1, Name = Measure.bit, isByte = false, Code="b"},
                new Unit(){ Id = 2, Name = Measure.Byte, isByte = true, Code="B"},
                new Unit(){ Id = 3, Name = Measure.Kilobit, isByte = false, Code="Kb"},
                new Unit(){ Id = 4, Name = Measure.Kilobyte, isByte = true, Code="KB"},
                new Unit(){ Id = 5, Name = Measure.Megabit, isByte = false, Code="Mb"},
                new Unit(){ Id = 6, Name = Measure.Megabyte, isByte = true, Code="MB"},
                new Unit(){ Id = 7, Name = Measure.Gigabit, isByte = false, Code="Gb"},
                new Unit(){ Id = 8, Name = Measure.Gigabyte, isByte = true, Code="GB"},
                new Unit(){ Id = 9, Name = Measure.Terabit, isByte = false, Code="Tb"},
                new Unit(){ Id = 10, Name = Measure.Terabyte, isByte = true, Code="TB"},
                new Unit(){ Id = 11, Name = Measure.Petabit, isByte = false, Code="Pb"},
                new Unit(){ Id = 12, Name = Measure.Petabyte, isByte = true, Code="PB"},
                new Unit(){ Id = 13, Name = Measure.Exabit, isByte = false, Code="Eb"},
                new Unit(){ Id = 14, Name = Measure.Exabyte, isByte = true, Code="EB"},
                new Unit(){ Id = 15, Name = Measure.Zettabit, isByte = false, Code="Zb"},
                new Unit(){ Id = 16, Name = Measure.Zettabyte, isByte = true, Code="ZB"},
                new Unit(){ Id = 17, Name = Measure.Yottabit, isByte = false, Code="Yb"},
                new Unit(){ Id = 18, Name = Measure.Yottabyte, isByte = true, Code="YB"},
            };             
        }

        public Measures(IUnit inputMeasure, KiloMultiplier multiplier) 
        {
            CalculateBaseMeasure(inputMeasure,multiplier);
            CalculateAllMeasures(multiplier);
        }
  
        /// <summary>
        /// Calculates all measures.
        /// </summary>
        /// <param name="multiplier">The multiplier.</param>
        private void CalculateAllMeasures(KiloMultiplier multiplier)
        {
            var baseMeasure = units.First(x => { return x.Id == 1; });
            foreach (var unit in units)
            {
                unit.Value = baseMeasure.Value * unit.CalculateFactor(multiplier);
            }
        }
  
        /// <summary>
        /// Calculates the base measure.
        /// </summary>
        /// <param name="inputMeasure">The input measure.</param>
        /// <param name="multiplier">The multiplier.</param>
        private void CalculateBaseMeasure(IUnit inputMeasure, KiloMultiplier multiplier)
        {
            units.First(x => { return x.Id == 1; }).Value = inputMeasure.Value * inputMeasure.CalculateFactor(multiplier);
        }

        public IEnumerable<IUnit> Units { get {return units;}}
    }
}
