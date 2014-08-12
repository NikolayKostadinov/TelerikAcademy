using System;
using System.Collections.Generic;

namespace CountryInfoSystemDAL.Model
{
    public partial class City
    {
        public City()
        {
            this.Countries = new List<Country>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public int Population { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
