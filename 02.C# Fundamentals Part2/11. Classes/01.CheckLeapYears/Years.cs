// -----------------------------------------------------------------------
// <copyright file="Years.cs" company="Manhattan">
// Checks if year is leap
// </copyright>
// -----------------------------------------------------------------------

namespace _01.CheckLeapYears
{
    using System;

    /// <summary>
    /// Checks if year is leap
    /// </summary>
    public class Years
    {
        private ushort year;

        public Years(ushort value)
        {
            this.Year = value;
        }

        public Years()
        {
            this.Year = (ushort)DateTime.Now.Year;
        }

        public ushort Year
        {
            get 
            {
                return this.year;
            }

            set
            {
                this.year = value;
            }
        }

        public bool IsLeapYear() 
        {
            bool checkYear = false;
            if (((this.Year % 4 == 0) && 
                (this.Year % 100 != 0)) ||
                (this.Year % 400 == 0))
            {
                checkYear = true;
            }

            return checkYear;
        }
    }
}
