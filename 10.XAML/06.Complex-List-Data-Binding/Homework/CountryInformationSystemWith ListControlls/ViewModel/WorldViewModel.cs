using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using CountryInfoSystemDAL.Data;
using CountryInfoSystemDAL.Data.Repositories;
using CountryInfoSystemDAL.Model;

namespace CountryInformationSystemWithListControlls.ViewModel
{
    public class WorldViewModel
    {
        private IRepository<Continent, int> continentsRepository = 
            new GenericRepository<Continent, int>(new WorldContext());  
        private IEnumerable<Continent> continents;

        public IEnumerable<Continent> Continents
        {
            get 
            {
                if (this.continents == null)
                {
                    this.continents = this.continentsRepository.All().ToList();
                }

                return this.continents;
            }
        }


    }
}
