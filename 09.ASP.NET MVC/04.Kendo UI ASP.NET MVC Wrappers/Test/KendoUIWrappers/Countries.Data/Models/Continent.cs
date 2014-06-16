using System;
using System.Collections.Generic;

namespace Countries.Data.Models
{
    public partial class Continent
    {
        public Continent()
        {
            this.Countries = new List<Country>();
        }

        public int ContinentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}