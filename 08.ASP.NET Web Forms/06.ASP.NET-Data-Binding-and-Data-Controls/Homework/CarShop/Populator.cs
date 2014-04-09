using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShop
{
    public class Populator
    {
        public static void PopulateProducers(ICollection<Producer> producers)
        {
            List<Model> fordModels = new List<Model>() 
            {
                new Model(){ Id = 0, Name = "Mondeo" },
                new Model(){ Id = 1, Name = "Focus" },
                new Model(){ Id = 2, Name = "Fusion" },
                new Model(){ Id = 3, Name = "Fiesta" }
            };
            producers.Add(new Producer()
            {
                Id = 0,
                Name = "Ford",
                Models = fordModels,
            });

            List<Model> toyotaModels = new List<Model>() 
            {
                new Model(){ Id = 0, Name = "Avensis" },
                new Model(){ Id = 1, Name = "Corola" },
                new Model(){ Id = 2, Name = "Hilux" },
                new Model(){ Id = 3, Name = "Landcruiser" }
            };
            producers.Add(new Producer()
            {
                Id = 1,
                Name = "Toyota",
                Models = toyotaModels,
            });

            List<Model> scodaModels = new List<Model>() 
            {
                new Model(){ Id = 0, Name = "Superb" },
                new Model(){ Id = 1, Name = "Octavia" },
                new Model(){ Id = 2, Name = "Felicia" },
                new Model(){ Id = 3, Name = "Favourit" }
            };
            producers.Add(new Producer()
            {
                Id = 2,
                Name = "Scoda",
                Models = scodaModels,
            });
        }

        public static ICollection<Extra> PopulateExtras() 
        {
            var extras = new List<Extra>() 
            {
                new Extra(){Id=0, Name="ABS"},
                new Extra(){Id = 1, Name = "Climatronic"},
                new Extra(){Id = 2, Name = "El. windows"},
                new Extra(){Id = 3, Name = "Automatic"},
                new Extra(){Id = 4, Name = "Leather"},
            };
            return extras;
        }

        public static EngineType[] GetEngineTypes() 
        {
            var engineTypes = 
                new EngineType[] 
                { 
                    new EngineType(){Id=0,Name="Benzine"},
                    new EngineType(){Id=0,Name="Diesel"},
                    new EngineType(){Id=0,Name="Electrical"},
                    new EngineType(){Id=0,Name="Hybrid"},
                };

            return engineTypes;
        }
    }
}