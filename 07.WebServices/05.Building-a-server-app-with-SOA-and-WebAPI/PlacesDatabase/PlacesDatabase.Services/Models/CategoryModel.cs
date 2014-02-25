using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlacesDatabase.Services.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PlacesCount { get; set; }
    }

    public class CategoryFullModel : CategoryModel
    {
        public IEnumerable<PlaceModel> Places { get; set; }
    }

}