using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CountryInfoSystem.Data;
using CountryInfoSystem.Data.Repositories;
using CountryInfoSystem.Model.Models;

namespace CountryInfoSystem.ViewModel
{
    public class WorlViewModel
    {

        private static IRepository<Country,string> countriesRepository = new GenericRepository<Country,string>(new WorldContext());

        private IList<City> cities;

        private IList<Country> countries;

        //public IList<City> Cities
        //{
        //    get
        //    {
        //        if (this.cities == null) 
        //        {
        //            FillCities();
        //        }
        //        return this.cities;
        //    }
        //}

        public IList<Country> Countries
        {
            get
            {
                if (this.countries == null)
                {
                    this.countries = countriesRepository.All().ToList();
                }
                return this.countries;
            }
        }

        public void PrevCity()
        {
            if (this.cities == null)
            {
                FillCities();
            }
            var citiesViewCollection = this.GetDefaultView(this.cities);
            citiesViewCollection.MoveCurrentToPrevious();
            if (citiesViewCollection.IsCurrentBeforeFirst)
            {
                citiesViewCollection.MoveCurrentToLast();
            }
        }

        public void NextCity()
        {
            if (this.cities == null) 
            {
                FillCities();
            }
            var citiesViewCollection = this.GetDefaultView(this.cities);
            citiesViewCollection.MoveCurrentToNext();
            if (citiesViewCollection.IsCurrentAfterLast)
            {
                citiesViewCollection.MoveCurrentToFirst();
            }
        }

        public void PrevCountry()
        {
            var countryViewCollection = this.GetDefaultView(this.countries);
            countryViewCollection.MoveCurrentToPrevious();
            if (countryViewCollection.IsCurrentBeforeFirst)
            {
                countryViewCollection.MoveCurrentToLast();
            }
            FillCities();
        }

        public void NextCountry()
        {
            var countryViewCollection = this.GetDefaultView(this.countries);
            countryViewCollection.MoveCurrentToNext();
            if (countryViewCollection.IsCurrentAfterLast)
            {
                countryViewCollection.MoveCurrentToFirst();
            }
            FillCities();
        }

        private ICollectionView GetDefaultView<T>(IEnumerable<T> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }

        private void FillCities()
        {
            var countryViewCollection = this.GetDefaultView(this.countries);
            var currentCountry = (Country)countryViewCollection.CurrentItem;
            this.cities = countriesRepository.GetById(currentCountry.Code).Cities.ToList();
        }
    }
}
