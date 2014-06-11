using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Countries.Data.Models;

namespace Countries.Data.ViewModels
{
    public class CountryViewModel
    {
        private byte[] flag;
        public static Expression<Func<Country, CountryViewModel>> ToCountryViewModel
        {
            get{
                return c => new CountryViewModel()
                    {
                        Code = c.Code,
                        Name = c.Name,
                        flag = c.Flag,
                        Continent = c.Continent.Name,
                        Region=c.Region,
                        SurfaceArea = c.SurfaceArea,
                        IndepYear = c.IndepYear,
                        Population = c.Population,
                        LifeExpectancy = c.LifeExpectancy,
                        GNP = c.GNP,
                        GNPOld = c.GNPOld,
                        LocalName = c.LocalName,
                        GovernmentForm = c.GovernmentForm,
                        HeadOfState = c.HeadOfState,
                        Capital= c.City.Name,
                        Code2 = c.Code2,
                        CountryLanguages = c.CountryLanguages.FirstOrDefault(x=>x.IsOfficial==true).Language,
                    };
           }
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Flag 
        { 
            get
            { 
                return this.flag!=null?Convert.ToBase64String(this.flag):"";
            } 
            set
            {
                this.flag = Convert.FromBase64CharArray(value.ToCharArray(),0,value.Length);
            } 
        }
        public string Continent { get; set; }
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
        public string Capital { get; set; }
        public string Code2 { get; set; }
        public string CountryLanguages { get; set; }
    }
}
