using System;
using System.Collections.Generic;

namespace CountryInfoSystem.Model.Models
{
    public partial class Country
    {
        public Country()
        {
            this.Cities = new List<City>();
            this.CountryLanguages = new List<CountryLanguage>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] Flag { get; set; }
        public int ContinentId { get; set; }
        public string Region { get; set; }
        public float SurfaceArea { get; set; }
        public Nullable<short> IndepYear { get; set; }
        public int Population { get; set; }
        public Nullable<float> LifeExpectancy { get; set; }
        public Nullable<float> GNP { get; set; }
        public Nullable<float> GNPOld { get; set; }
        public string LocalName { get; set; }
        public string GovernmentForm { get; set; }
        public string HeadOfState { get; set; }
        public Nullable<int> Capital { get; set; }
        public string Code2 { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual City City { get; set; }
        public virtual Continent Continent { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
    }
}
