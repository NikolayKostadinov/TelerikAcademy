using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain
{
    public class MeasuresCalculator
    {
        private static IEnumerable<IUnit> units;
        private KiloMultiplier multiplier;
        static MeasuresCalculator()
        {
            PopulateMeasures();
        }

        private static void PopulateMeasures()
        {
            units = new Unit[]
            {
                new Unit(){ Id = 1, Name = Measure.bit, Code="b"},
                new Unit(){ Id = 2, Name = Measure.Byte, Code="B"},
                new Unit(){ Id = 3, Name = Measure.Kilobit, Code="Kb"},
                new Unit(){ Id = 4, Name = Measure.KiloByte, Code="KB"},
                new Unit(){ Id = 5, Name = Measure.Megabit, Code="Mb"},
                new Unit(){ Id = 6, Name = Measure.MegaByte, Code="MB"},
                new Unit(){ Id = 7, Name = Measure.Gigabit, Code="Gb"},
                new Unit(){ Id = 8, Name = Measure.GigaByte, Code="GB"},
                new Unit(){ Id = 9, Name = Measure.Terabit, Code="Tb"},
                new Unit(){ Id = 10, Name = Measure.TeraByte,  Code="TB"},
                new Unit(){ Id = 11, Name = Measure.Petabit, Code="Pb"},
                new Unit(){ Id = 12, Name = Measure.PetaByte, Code="PB"},
                new Unit(){ Id = 13, Name = Measure.Exabit, Code="Eb"},
                new Unit(){ Id = 14, Name = Measure.ExaByte, Code="EB"},
                new Unit(){ Id = 15, Name = Measure.Zettabit, Code="Zb"},
                new Unit(){ Id = 16, Name = Measure.ZettaByte, Code="ZB"},
                new Unit(){ Id = 17, Name = Measure.Yottabit, Code="Yb"},
                new Unit(){ Id = 18, Name = Measure.YottaByte, Code="YB"},
            };
            Console.WriteLine();
        }

        public MeasuresCalculator(IUnit inputMeasure, KiloMultiplier multiplier)
        {
            this.multiplier = multiplier;
            CalculateBaseMeasure(inputMeasure, multiplier);
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
                unit.Value = baseMeasure.Value / unit.CalculateFactor(multiplier);
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

        public IEnumerable<IUnit> Units { get { return units; } }

        public KiloMultiplier Multiplier { get { return this.multiplier; } }
    }
}
