namespace Atm.Data.Models
{
    using System.Data.Entity;
    using Atm.Data.Models.Mapping;
    using Atm.Model;

    public partial class AtmContext : DbContext
    {
        static AtmContext()
        {
            Database.SetInitializer<AtmContext>(null);
        }

        public AtmContext()
            : base("Name=AtmContextWork")
        {
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CardAccountMap());
        }
    }
}
