using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Countries.Data.Models.Mapping;

namespace Countries.Data.Models
{
    public partial class WorldContext : DbContext
    {
        static WorldContext()
        {
            Database.SetInitializer<WorldContext>(null);
        }

        public WorldContext()
            : base("Name=WorldContext")
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryLanguage> CountryLanguages { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new ContinentMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CountryLanguageMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
