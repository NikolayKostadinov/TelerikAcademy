using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _04.PersonAgeValidation
{
    class AgeValidationRule : ValidationRule
    {
        /// <summary>
        /// When overridden in a derived class, performs validation checks on a
        /// value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>
        /// A <see cref="T:System.Windows.Controls.ValidationResult" /> object.
        /// </returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double input;
            int inputAge;
            if (double.TryParse(value.ToString(), out input))
            {
                inputAge = (int)Math.Ceiling(input);
                
                if (0 >= inputAge || inputAge > 100)
                {
                    return new ValidationResult(false, "Age is out of range");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            else
            {
                return new ValidationResult(false, "Invalid Age");
            }
        }
    }
}
