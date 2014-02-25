using PlacesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDatabase.DataLayer
{
    public class PlacesContext : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        public PlacesContext()
            : base("PlacesDb")
        {
        }
    }
}
