using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Calculator.Domain
{
    public static class MeasureCaclulatorHelper
    {
        public static IEnumerable<SelectListItem> ToSelectListItem(this MeasuresCalculator measuresCalculator)
        {
            IList<SelectListItem> measureListItems = new List<SelectListItem>();
             
            foreach (var unit in measuresCalculator.Units)
            {
                measureListItems.Add(new SelectListItem() { Text= unit.Name + " - " + unit.Code, Value = ((int)unit.Name).ToString(), Selected = (unit.Name == Measure.MegaByte)});

            }

            return measureListItems;
        }
    }
}
